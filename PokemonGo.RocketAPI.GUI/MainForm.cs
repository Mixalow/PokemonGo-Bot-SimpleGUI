using System;
using System.Device.Location;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using PokemonGo.RocketAPI.Enums;
using PokemonGo.RocketAPI.Extensions;
using PokemonGo.RocketAPI.GeneratedCode;
using PokemonGo.RocketAPI.Logic;
using PokemonGo.RocketAPI.Logic.Utils;
using Timer = System.Windows.Forms.Timer;

namespace PokemonGo.RocketAPI.GUI {
    public partial class MainForm : Form {
        private readonly Timer sessionTimer = new Timer();
        private bool botPaused;
        private Client client;

        private int globalBotSpeed = 5000;
        private Inventory inventory;

        private bool isFarmingActive;
        private bool locationChanged;
        public string[] loginDetails = new string[2];

        public bool loginSelected;
        private int pokemonCaughtCount;
        private int pokestopsCount;
        private GetPlayerResponse profile;
        public AuthType sAType = AuthType.Google;
        private DateTime sessionStartTime;
        private Settings settings;

        private double totalExperience;

        public MainForm() {
            InitializeComponent();
            startLogger();
            cleanUp();
        }

        private void cleanUp() {
            // Clear Labels
            lbExpHour.Text = string.Empty;
            lbPkmnCaptured.Text = string.Empty;
            lbPkmnHr.Text = string.Empty;

            // Clear Labels
            lbName.Text = string.Empty;
            lbLevel.Text = string.Empty;
            lbExperience.Text = string.Empty;
            lbItemsInventory.Text = string.Empty;
            lbPokemonsInventory.Text = string.Empty;

            // Clear Experience
            totalExperience = 0;
            pokemonCaughtCount = 0;
        }

        private void initializeMap() {
            try {
                // Load the Map Settings
                //MainMap.OnMapDrag += MainMap_OnMapDrag;
                //MainMap.DragButton = MouseButtons.Left;
                MainMap.MapProvider = GMapProviders.GoogleMap;
                MainMap.Position = new PointLatLng(UserSettings.Default.DefaultLatitude, UserSettings.Default.DefaultLongitude);
                MainMap.MinZoom = 0;
                MainMap.MaxZoom = 24;
                MainMap.Zoom = 15;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private async void MainForm_Load(object sender, EventArgs e) {
            try {
                await displayLoginWindow();
                displayPositionSelector();
                await GetCurrentPlayerInformation();
                await preflightCheck();

                dGrid.ColumnCount = 3;
                dGrid.Columns[0].Name = "Action";
                dGrid.Columns[1].Name = "Pokemon / Amount";
                dGrid.Columns[2].Name = "CP / Item / Experience";

                humanWalking.Checked = UserSettings.Default.UseHumanLikeWalking;
                farmPokemonCheck.Checked = UserSettings.Default.catchPokemon;
                farmPokestopsCheck.Checked = UserSettings.Default.collectPokestops;
                cbKeepPkToEvolve.Checked = UserSettings.Default.keepEvolvablePokemon;
                IVOverCPCheck.Checked = UserSettings.Default.PrioritizeIVOverCP;
                numericUpDown1.Value = UserSettings.Default.DelayBetweenMove;
                botWalkSpeed.Value = (decimal)UserSettings.Default.WalkingSpeedInKilometerPerHour;
                bAlt.Value = (decimal)UserSettings.Default.DefaultAltitude;
                maxTravelDist.Value = (decimal) UserSettings.Default.maxTravelDistance;
                numericUpDown2.Value = (decimal)UserSettings.Default.KeepMinCP;
                numericUpDown3.Value = (decimal)UserSettings.Default.KeepMinIVPercentage;
                autoRecycleCheck.Checked = UserSettings.Default.autoRecycleItems;
                autoTransferCheck.Checked = UserSettings.Default.autoTransferPokemon;
                evolveAboveIv.Value = UserSettings.Default.evolveAboveIvValue;
                evolveAboveCp.Value = UserSettings.Default.evolveAboveCp;
                duplicateToKeep.Value = (decimal) UserSettings.Default.duplicatePokemonToKeep;
                UserSettings.Default.Save();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                Logger.Write(ex.Message);
            }
        }

        private void displayPositionSelector() {
            // Display Position Selector
            if (loginSelected) {
                botPaused = true;
                var locationSelect = new LocationSelector();
                locationSelect.ShowDialog();

                // Check if Position was Selected
                try {
                    if (!locationSelect.setPos)
                        throw new ArgumentException();

                    // Persisting the Initial Position
                    client.SaveLatLng(locationSelect.lat, locationSelect.lng);
                    client.SetCoordinates(locationSelect.lat, locationSelect.lng, UserSettings.Default.DefaultAltitude);
                    Logger.Write($"Starting in Location Lat: {UserSettings.Default.DefaultLatitude} Lng: {UserSettings.Default.DefaultLongitude}");

                    // Close the Location Window
                    locationSelect.Close();
                    initializeMap();
                    botPaused = false;
                }
                catch {
                    MessageBox.Show("Please Select A Starting Point!", "Error");
                    locationSelect.Close();
                    displayPositionSelector();
                }
            }
        }

        private async Task displayLoginWindow() {
            // Display Login
            Hide();
            var loginForm = new LoginForm();
            loginForm.ShowDialog();
            Show();

            // Check if an Option was Selected
            if (!loginForm.loginSelected)
                Application.Exit();

            loginSelected = loginForm.loginSelected;
            sAType = loginForm.auth;
            loginDetails[0] = loginForm.boxUsername.Text;
            loginDetails[1] = loginForm.boxPassword.Text;

            // Determine Login Method
            if (loginForm.auth == AuthType.Ptc)
                await loginPtc(loginForm.boxUsername.Text, loginForm.boxPassword.Text);
            if (loginForm.auth == AuthType.Google)
                await loginGoogle();


            // Select the Location
            Logger.Write("Select Starting Location...");

            // Close the Login Form
            loginForm.Close();
        }

        private void startLogger() {
            var GUILog = new GUILogger(LogLevel.Info);
            GUILog.setLoggingBox(loggingBox);
            Logger.SetLogger(GUILog);
        }

        private async Task loginGoogle() {
            try {
                // Creating the Settings
                Logger.Write("Adjusting the Settings.");
                UserSettings.Default.AuthType = AuthType.Google.ToString();
                settings = new Settings();

                // Begin Login
                var client = new Client(settings);
                await client.DoGoogleLogin();
                await client.SetServer();
                Logger.Write("Logged In With Google Token /" + settings.GoogleRefreshToken);

                // Server Ready
                Logger.Write("Connected! Server is Ready.");
                this.client = client;

                Logger.Write("Attempting to Retrieve Inventory and Player Profile...");
                inventory = new Inventory(client);
                profile = await client.GetProfile();
            }
            catch {
                Logger.Write("Unable to Connect using the Google Token.");
                MessageBox.Show("Unable to Authenticate with Login Server.", "Login Problem");
                loginSelected = false;
                Application.Exit();
            }
        }

        private async Task loginPtc(string username, string password) {
            try {
                // Creating the Settings
                Logger.Write("Adjusting the Settings.");
                UserSettings.Default.AuthType = AuthType.Ptc.ToString();
                UserSettings.Default.PtcUsername = username;
                UserSettings.Default.PtcPassword = password;
                settings = new Settings();

                // Begin Login
                Logger.Write("Trying to Login with PTC Credentials...");
                var client = new Client(settings);
                await client.DoPtcLogin(settings.PtcUsername, settings.PtcPassword);
                await client.SetServer();

                // Server Ready
                Logger.Write("Connected! Server is Ready.");
                this.client = client;

                Logger.Write("Attempting to Retrieve Inventory and Player Profile...");
                inventory = new Inventory(client);
                profile = await client.GetProfile();
            }
            catch {
                Logger.Write("Unable to Connect using the PTC Credentials.");
                MessageBox.Show("Unable to Authenticate with Login Server.", "Login Problem");
                loginSelected = false;
                Application.Exit();
            }
        }

        private async Task<bool> preflightCheck() {
            // Get Pokemons and Inventory
            var myItems = await inventory.GetItems();
            var myPokemons = await inventory.GetPokemons();

            // Write to Console
            //Logger.Write($"Items in Bag: {myItems.Select(i => i.Count).Sum()}/350.");
            //Logger.Write($"Pokemons in Bag: {myPokemons.Count()}/250.");

            // Checker for Inventory
            if (myItems.Select(i => i.Count).Sum() >= 350 && autoRecycleCheck.Checked) {
                Logger.Write("Item Overflow Detected - Cleaning");
                btnRecycleItems_Click(null, null);
            }

            // Checker for Pokemons
            if (myPokemons.Count() >= 241 && autoTransferCheck.Checked) // Eggs are Included in the total count (9/9)
            {
                Logger.Write("Pokemon Overflow Detected - Cleaning");
                btnTransferDuplicates_Click(null, null);
            }

            // Ready to Fly
            Logger.Write("Inventory and Pokemon Space, Ready.");
            return true;
        }


        ///////////////////
        // Buttons Logic //
        ///////////////////

        private async void btnStartFarming_Click(object sender, EventArgs e) {
            if (!await preflightCheck())
                return;

            btnStartFarming.Enabled = false;
            btnStopFarming.Enabled = true;

            // Setup the Timer
            isFarmingActive = true;
            botPaused = false;
            setUpTimer();
            startBottingSession();

            // Clear Grid
            dGrid.Rows.Clear();

            // Prepare Grid
            dGrid.ColumnCount = 3;
            dGrid.Columns[0].Name = "Action";
            dGrid.Columns[1].Name = "Pokemon / Amount";
            dGrid.Columns[2].Name = "CP / Item / Experience";
        }

        private void btnStopFarming_Click(object sender, EventArgs e) {
            btnStartFarming.Enabled = true;
            button1.Enabled = true;
            btnStopFarming.Enabled = false;

            // Close the Timer
            isFarmingActive = false;
            stopBottingSession();
        }

        private async void btnEvolvePokemons_Click(object sender, EventArgs e) {
            //Evovle Pokemons
            await EvolveAllPokemonWithEnoughCandy();
        }

        private async void btnTransferDuplicates_Click(object sender, EventArgs e) {
            // Transfer Pokemons
            await TransferDuplicatePokemon(cbKeepPkToEvolve.Checked, IVOverCPCheck.Checked);
        }

        private async void btnRecycleItems_Click(object sender, EventArgs e) {
            // Recycle Items
            await RecycleItems();
        }

        ////////////////////////
        // EXP COUNTER MODULE //
        ////////////////////////


        private void setUpTimer() {
            sessionTimer.Tick += timerTick;
            sessionTimer.Enabled = true;
        }

        private void timerTick(object sender, EventArgs e) {
            lbExpHour.Text = getExpPerHour();
            lbPkmnHr.Text = getPokemonPerHour();
            lbPkmnCaptured.Text = "Pokemons Captured: " + pokemonCaughtCount;
        }

        private string getExpPerHour() {
            var expPerHour = (totalExperience*3600)/(DateTime.Now - sessionStartTime).TotalSeconds;
            return $"Exp/Hr: {expPerHour:0.0}";
        }

        private string getPokemonPerHour() {
            var pkmnPerHour = (pokemonCaughtCount*3600)/(DateTime.Now - sessionStartTime).TotalSeconds;
            return $"Pkmn/Hr: {pkmnPerHour:0.0}";
        }

        private async void startBottingSession() {
            // Setup the Timer
            sessionTimer.Interval = 1000;
            sessionTimer.Start();
            sessionStartTime = DateTime.Now;

            // Loop Until we Manually Stop
            while (isFarmingActive) {
                if (!botPaused) {
                    try {
                        // Start Farming Pokestops/Pokemons.
                        await ExecuteFarmingPokestopsAndPokemons();
                        Thread.Sleep(100);
                    }
                    catch (Exception ex) {
                        Logger.Write("InvalidResponseException - Reconnecting Bot (Please Wait...)");
                        //createCrashLog(ex);
                        Thread.Sleep(1000);
                        if (sAType == AuthType.Ptc)
                            await loginPtc(loginDetails[0], loginDetails[1]);
                        if (sAType == AuthType.Google)
                            await loginGoogle();
                    }
                }
            }
        }

        private void createCrashLog(Exception ex) {
            try {
                var filename = "CrashLog." + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".txt";

                using (var w = new StreamWriter(filename, true)) {
                    w.WriteLine("Message: " + ex.Message);
                    w.WriteLine("StackTrace: " + ex.StackTrace);
                }
            }
            catch {
                Logger.Write("Unable to Create Crash Log.");
            }
        }

        private void stopBottingSession() {
            sessionTimer.Stop();

            boxPokestopName.Clear();
            boxPokestopInit.Clear();
            boxPokestopCount.Clear();

            Logger.Write("Bot Stopped! - Please Allow Pending Tasks To Complete");

            //MessageBox.Show("Please allow a few seconds for the pending tasks to complete.");
        }

        ///////////////////////
        // API LOGIC MODULES //
        ///////////////////////

        public async Task GetCurrentPlayerInformation() {
            var playerName = profile.Profile.Username ?? "";
            var playerStats = await inventory.GetPlayerStats();
            var playerStat = playerStats.FirstOrDefault();
            if (playerStat != null) {
                var xpDifference = GetXPDiff(playerStat.Level);
                var message = $"{playerName} | Level {playerStat.Level}: {playerStat.Experience - playerStat.PrevLevelXp - xpDifference}/{playerStat.NextLevelXp - playerStat.PrevLevelXp - xpDifference}XP";
                lbName.Text = $"Name: {playerName}";
                lbLevel.Text = $"Level: {playerStat.Level}";
                lbExperience.Text = $"Experience: {playerStat.Experience - playerStat.PrevLevelXp - xpDifference}/{playerStat.NextLevelXp - playerStat.PrevLevelXp - xpDifference} XP";
            }

            // Get Pokemons and Inventory
            var myItems = await inventory.GetItems();
            var myPokemons = await inventory.GetPokemons();

            // Write to Console
            lbItemsInventory.Text = $"Inventory: {myItems.Select(i => i.Count).Sum()}/350";
            lbPokemonsInventory.Text = $"Pokemons: {myPokemons.Count()}/250";
        }

        public static int GetXPDiff(int level) {
            switch (level) {
                case 1:
                    return 0;
                case 2:
                    return 1000;
                case 3:
                    return 2000;
                case 4:
                    return 3000;
                case 5:
                    return 4000;
                case 6:
                    return 5000;
                case 7:
                    return 6000;
                case 8:
                    return 7000;
                case 9:
                    return 8000;
                case 10:
                    return 9000;
                case 11:
                    return 10000;
                case 12:
                    return 10000;
                case 13:
                    return 10000;
                case 14:
                    return 10000;
                case 15:
                    return 15000;
                case 16:
                    return 20000;
                case 17:
                    return 20000;
                case 18:
                    return 20000;
                case 19:
                    return 25000;
                case 20:
                    return 25000;
                case 21:
                    return 50000;
                case 22:
                    return 75000;
                case 23:
                    return 100000;
                case 24:
                    return 125000;
                case 25:
                    return 150000;
                case 26:
                    return 190000;
                case 27:
                    return 200000;
                case 28:
                    return 250000;
                case 29:
                    return 300000;
                case 30:
                    return 350000;
                case 31:
                    return 500000;
                case 32:
                    return 500000;
                case 33:
                    return 750000;
                case 34:
                    return 1000000;
                case 35:
                    return 1250000;
                case 36:
                    return 1500000;
                case 37:
                    return 2000000;
                case 38:
                    return 2500000;
                case 39:
                    return 1000000;
                case 40:
                    return 1000000;
            }
            return 0;
        }

        private async Task EvolveAllPokemonWithEnoughCandy() {
            botPaused = true;
            var pokemonToEvolve = await inventory.GetPokemonToEvolve();
            foreach (var pokemon in pokemonToEvolve) {
                var evolvePokemonOutProto = await client.EvolvePokemon(pokemon.Id);

                if (evolvePokemonOutProto.Result == EvolvePokemonOut.Types.EvolvePokemonStatus.PokemonEvolvedSuccess) {
                    Logger.Write($"Evolved {pokemon.PokemonId} successfully for {evolvePokemonOutProto.ExpAwarded}xp", LogLevel.Info);

                    // GUI Experience
                    totalExperience += evolvePokemonOutProto.ExpAwarded;
                    dGrid.Rows.Insert(0, "Evolved", pokemon.PokemonId.ToString(), evolvePokemonOutProto.ExpAwarded + " XP");
                }
                else {
                    Logger.Write($"Failed to evolve {pokemon.PokemonId}. EvolvePokemonOutProto.Result was {evolvePokemonOutProto.Result}, stopping evolving {pokemon.PokemonId}", LogLevel.Info);
                }

                await GetCurrentPlayerInformation();
                await Task.Delay(100);
            }

            // Logging
            Logger.Write("Finished Evolving Pokemon(s).");
            botPaused = false;
        }

        private async Task TransferDuplicatePokemon(bool keepPokemonsThatCanEvolve = false, bool prioritizeIVoverCP = false) {
            // Logging
            Logger.Write("Transferring Duplicate Pokemon(s).");
            botPaused = true;
            var duplicatePokemons = await inventory.GetDuplicatePokemonToTransfer(keepPokemonsThatCanEvolve, prioritizeIVoverCP);

            foreach (var duplicatePokemon in duplicatePokemons) {
                var transfer = await client.TransferPokemon(duplicatePokemon.Id);
                await GetCurrentPlayerInformation();

                Logger.Write($"Transfer {duplicatePokemon.PokemonId} with {duplicatePokemon.Cp} CP", LogLevel.Info);
                dGrid.Rows.Insert(0, "Transferred", duplicatePokemon.PokemonId.ToString(), duplicatePokemon.Cp + " CP" + " / " + Math.Round(duplicatePokemon.CalculateIV(), 2) + "% IV");
                await Task.Delay(100);
            }

            // Logging
            Logger.Write("Finished Transfering Pokemon(s).");
            botPaused = false;
        }

        private async Task RecycleItems() {
            try {
                // Logging
                botPaused = true;
                Logger.Write("Recylcing Items!");

                var items = await inventory.GetItemsToRecycle(settings);

                foreach (var item in items) {
                    var transfer = await client.RecycleItem((ItemId) item.Item_, item.Count);
                    Logger.Write($"Recycled {item.Count}x {(ItemId) item.Item_}", LogLevel.Info);

                    // GUI Experience
                    dGrid.Rows.Insert(0, "Recycled", item.Count.ToString(), ((ItemId) item.Item_).ToString());

                    await Task.Delay(100);
                }


                // Logging
                botPaused = false;
                Logger.Write("Recycling Complete.");
            }
            catch (Exception ex) {
                Logger.Write($"Error Details: {ex.Message}");
                Logger.Write("Unable to Complete Items Recycling.");
            }
            botPaused = false;
        }

        private async Task<MiscEnums.Item> GetBestBall(int? pokemonCp) {
            var pokeBallsCount = await inventory.GetItemAmountByType(MiscEnums.Item.ITEM_POKE_BALL);
            var greatBallsCount = await inventory.GetItemAmountByType(MiscEnums.Item.ITEM_GREAT_BALL);
            var ultraBallsCount = await inventory.GetItemAmountByType(MiscEnums.Item.ITEM_ULTRA_BALL);
            var masterBallsCount = await inventory.GetItemAmountByType(MiscEnums.Item.ITEM_MASTER_BALL);

            if (masterBallsCount > 0 && pokemonCp >= 1000)
                return MiscEnums.Item.ITEM_MASTER_BALL;
            if (ultraBallsCount > 0 && pokemonCp >= 1000)
                return MiscEnums.Item.ITEM_ULTRA_BALL;
            if (greatBallsCount > 0 && pokemonCp >= 1000)
                return MiscEnums.Item.ITEM_GREAT_BALL;

            if (ultraBallsCount > 0 && pokemonCp >= 600)
                return MiscEnums.Item.ITEM_ULTRA_BALL;
            if (greatBallsCount > 0 && pokemonCp >= 600)
                return MiscEnums.Item.ITEM_GREAT_BALL;

            if (greatBallsCount > 0 && pokemonCp >= 350)
                return MiscEnums.Item.ITEM_GREAT_BALL;

            if (pokeBallsCount > 0)
                return MiscEnums.Item.ITEM_POKE_BALL;
            if (greatBallsCount > 0)
                return MiscEnums.Item.ITEM_GREAT_BALL;
            if (ultraBallsCount > 0)
                return MiscEnums.Item.ITEM_ULTRA_BALL;
            if (masterBallsCount > 0)
                return MiscEnums.Item.ITEM_MASTER_BALL;

            return MiscEnums.Item.ITEM_POKE_BALL;
        }

        public async Task UseBerry(ulong encounterId, string spawnPointId) {
            var inventoryBalls = await inventory.GetItems();
            var berries = inventoryBalls.Where(p => (ItemId) p.Item_ == ItemId.ItemRazzBerry);
            var berry = berries.FirstOrDefault();

            if (berry == null)
                return;

            var useRaspberry = await client.UseCaptureItem(encounterId, ItemId.ItemRazzBerry, spawnPointId);
            Logger.Write($"Used Rasperry. Remaining: {berry.Count}", LogLevel.Info);
            await Task.Delay(3000);
        }

        private async Task ExecuteFarmingPokestopsAndPokemons() {
            var mapObjects = await client.GetMapObjects();
            var pokeStops = mapObjects.MapCells.SelectMany(i => i.Forts).Where(i => i.Type == FortType.Checkpoint && i.CooldownCompleteTimestampMs < DateTime.UtcNow.ToUnixTime() && (LocationUtils.CalculateDistanceInMeters1(client.CurrentLat, client.CurrentLng, i.Latitude, i.Longitude) < (double)maxTravelDist.Value) || (double)maxTravelDist.Value == 0);

            pokestopsCount = pokeStops.Count<FortData>();
            var pokeStopsList = pokeStops.ToList();
            var count = 1;

            while (pokeStopsList.Any()) {
                pokeStopsList = pokeStopsList.OrderBy(i => LocationUtils.CalculateDistanceInMeters1(client.CurrentLat, client.CurrentLng, i.Latitude, i.Longitude)).ToList();
                var pokeStop = pokeStopsList[0];
                pokeStopsList.RemoveAt(0);

                if (humanWalking.Checked) {
                    Navigation c = new Navigation(client);
                    MainMap.Position = new PointLatLng(0, 0);
                    var update = await c.HumanLikeWalking(new Navigation.Location(pokeStop.Latitude, pokeStop.Longitude), (double) botWalkSpeed.Value, ExecuteCatchAllNearbyPokemons, MainMap);
                }
                else {
                    var update = await client.UpdatePlayerLocation(pokeStop.Latitude, pokeStop.Longitude, UserSettings.Default.DefaultAltitude);
                    MainMap.Position = new PointLatLng(client.CurrentLat, client.CurrentLng);
                }

                var fortInfo = await client.GetFort(pokeStop.Id, pokeStop.Latitude, pokeStop.Longitude);

                boxPokestopName.Text = fortInfo.Name.ToString();
                boxPokestopInit.Text = count.ToString();
                boxPokestopCount.Text = pokestopsCount.ToString();
                count++;
                if (farmPokestopsCheck.Checked) {
                    var fortSearch = await client.SearchFort(pokeStop.Id, pokeStop.Latitude, pokeStop.Longitude);
                    string eggInfo = fortSearch.PokemonDataEgg != null ? "1" : "0";
                    Logger.Write($"Pokestop Farmed / XP: {fortSearch.ExperienceAwarded} Gems: {fortSearch.GemsAwarded}, Eggs: {eggInfo} Items: {StringUtils.GetSummedFriendlyNameOfItemAwardList(fortSearch.ItemsAwarded)}", LogLevel.Info);

                    var myItems = await inventory.GetItems();
                    var myPokemons = await inventory.GetPokemons();

                    if (myItems.Select(i => i.Count).Sum() >= 350 || autoRecycleCheck.Checked)
                        btnRecycleItems_Click(null, null);
                    if (myPokemons.Count() >= 241 || autoTransferCheck.Checked) // Eggs are Included in the total count (9/9)
                        btnTransferDuplicates_Click(null, null);

                    // Experience Counter
                    totalExperience += fortSearch.ExperienceAwarded;
                }

                await GetCurrentPlayerInformation();
                if (farmPokemonCheck.Checked)
                    await ExecuteCatchAllNearbyPokemons();

                if (!isFarmingActive)
                    return;

                if (locationChanged) {
                    locationChanged = false;
                    break;
                }
                await Task.Delay(globalBotSpeed);
            }
        }

        private async Task ExecuteCatchAllNearbyPokemons() {
            if (farmPokemonCheck.Checked) {
                var mapObjects = await client.GetMapObjects();

                var pokemons = mapObjects.MapCells.SelectMany(i => i.CatchablePokemons);

                foreach (var pokemon in pokemons) {
                    var update = await client.UpdatePlayerLocation(pokemon.Latitude, pokemon.Longitude, settings.DefaultAltitude);
                    var encounterPokemonResponse = await client.EncounterPokemon(pokemon.EncounterId, pokemon.SpawnpointId);
                    var pokemonCP = encounterPokemonResponse?.WildPokemon?.PokemonData?.Cp;
                    var pokeball = await GetBestBall(pokemonCP);

                    MainMap.Position = new PointLatLng(client.CurrentLat, client.CurrentLng);

                    Logger.Write($"Fighting {pokemon.PokemonId} with Capture Probability of {(encounterPokemonResponse?.CaptureProbability.CaptureProbability_.First())*100:0.0}%");

                    boxPokemonName.Text = pokemon.PokemonId.ToString();
                    boxPokemonCaughtProb.Text = (encounterPokemonResponse?.CaptureProbability.CaptureProbability_.First()*100).ToString() + "%";

                    CatchPokemonResponse caughtPokemonResponse;
                    do {
                        if (encounterPokemonResponse?.CaptureProbability.CaptureProbability_.First() < 0.4) {
                            //Throw berry is we can
                            await UseBerry(pokemon.EncounterId, pokemon.SpawnpointId);
                        }

                        caughtPokemonResponse = await client.CatchPokemon(pokemon.EncounterId, pokemon.SpawnpointId, pokemon.Latitude, pokemon.Longitude, pokeball);
                        await Task.Delay(globalBotSpeed);
                    } while (caughtPokemonResponse.Status == CatchPokemonResponse.Types.CatchStatus.CatchMissed);

                    Logger.Write(caughtPokemonResponse.Status == CatchPokemonResponse.Types.CatchStatus.CatchSuccess ? $"We caught a {pokemon.PokemonId} with CP {encounterPokemonResponse?.WildPokemon?.PokemonData?.Cp} using a {pokeball}" : $"{pokemon.PokemonId} with CP {encounterPokemonResponse?.WildPokemon?.PokemonData?.Cp} got away while using a {pokeball}..", LogLevel.Info);

                    if (caughtPokemonResponse.Status == CatchPokemonResponse.Types.CatchStatus.CatchSuccess) {
                        // Calculate Experience
                        var fightExperience = 0;
                        foreach (var exp in caughtPokemonResponse.Scores.Xp)
                            fightExperience += exp;
                        totalExperience += fightExperience;
                        Logger.Write("Gained " + fightExperience + " XP.");
                        pokemonCaughtCount++;

                        // Add Row to the DataGrid
                        dGrid.Rows.Insert(0, "Captured", pokemon.PokemonId.ToString(), encounterPokemonResponse?.WildPokemon?.PokemonData?.Cp + " CP" + " / " + Math.Round((double)encounterPokemonResponse?.WildPokemon?.PokemonData?.CalculateIV(), 2) + "% IV");
                    }
                    else {
                        // Add Row to the DataGrid
                        dGrid.Rows.Insert(0, "Ran Away", pokemon.PokemonId.ToString(), encounterPokemonResponse?.WildPokemon?.PokemonData?.Cp + " CP" + " / " + Math.Round((double)encounterPokemonResponse?.WildPokemon?.PokemonData?.CalculateIV(), 2) + "% IV");
                    }

                    boxPokemonName.Clear();
                    boxPokemonCaughtProb.Clear();

                    await GetCurrentPlayerInformation();

                    if (!isFarmingActive)
                        return;
                    await Task.Delay(2000);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            locationChanged = true;
            displayPositionSelector();
        }

        private void openNewBotToolStripMenuItem_Click_1(object sender, EventArgs e) {
            Process.Start("PoGoBot-GUI.exe");
        }

        private void farmPokestopsCheck_CheckedChanged(object sender, EventArgs e) {
            if (farmPokestopsCheck.Checked)
                Logger.Write("PokeStop Collecting Enabled, Bot Will Loot Nearby PokeStops");
            else
                Logger.Write("PokeStop Collecting Disabled, Bot Will Not Loot Nearby PokeStops");
            UserSettings.Default.collectPokestops = farmPokestopsCheck.Checked;
            UserSettings.Default.Save();
        }

        private void numericUpDown1_Leave(object sender, EventArgs e) {
            
        }

        private void farmPokemonCheck_CheckedChanged(object sender, EventArgs e) {
            if (farmPokemonCheck.Checked)
                Logger.Write("Pokemon Catching Enabled, Bot Will Catch Nearby Pokemon");
            else
                Logger.Write("Pokemon Catching Disabled, Bot Will Not Catch Nearby Pokemon");
            UserSettings.Default.catchPokemon = farmPokemonCheck.Checked;
            UserSettings.Default.Save();
        }

        private void bAlt_ValueChanged(object sender, EventArgs e) {
            double alt = (double)bAlt.Value;
            client.Settings.DefaultAltitude = alt;
            UserSettings.Default.DefaultAltitude = alt;
            UserSettings.Default.Save();
        }

        private void humanWalking_CheckedChanged(object sender, EventArgs e) {
            if (humanWalking.Checked)
                botWalkSpeed.Enabled = true;
            else
                botWalkSpeed.Enabled = false;
            UserSettings.Default.UseHumanLikeWalking = humanWalking.Checked;
            UserSettings.Default.Save();
        }

        private void maxTravelDist_ValueChanged(object sender, EventArgs e)
        {
            UserSettings.Default.maxTravelDistance = (double)maxTravelDist.Value;
            UserSettings.Default.Save();
        }

        private void botWalkSpeed_ValueChanged(object sender, EventArgs e) {
            double speed = (double) botWalkSpeed.Value;
            client.Settings.WalkingSpeedInKilometerPerHour = speed;
            UserSettings.Default.WalkingSpeedInKilometerPerHour = speed;
            UserSettings.Default.Save();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            globalBotSpeed = (int)numericUpDown1.Value;
            Logger.Write("Bot Speed Set To " + globalBotSpeed + " MS");
            UserSettings.Default.DelayBetweenMove = globalBotSpeed;
            UserSettings.Default.Save();
        }

        private void cbKeepPkToEvolve_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.Default.keepEvolvablePokemon = cbKeepPkToEvolve.Checked;
            UserSettings.Default.Save();
        }

        private void IVOverCPCheck_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.Default.PrioritizeIVOverCP = IVOverCPCheck.Checked;
            UserSettings.Default.Save();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e) {
            UserSettings.Default.KeepMinCP = (int)numericUpDown2.Value;
            UserSettings.Default.Save();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            UserSettings.Default.KeepMinIVPercentage = (float)numericUpDown3.Value;
            UserSettings.Default.Save();
        }

        private void autoTransferCheck_CheckedChanged(object sender, EventArgs e) {
            UserSettings.Default.autoTransferPokemon = autoTransferCheck.Checked;
            UserSettings.Default.Save();
        }

        private void autoRecycleCheck_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.Default.autoRecycleItems = autoRecycleCheck.Checked;
            UserSettings.Default.Save();
        }

        private void evolveAboveIv_ValueChanged(object sender, EventArgs e) {
            UserSettings.Default.evolveAboveIvValue = (int)evolveAboveIv.Value;
            UserSettings.Default.Save();
        }

        private void duplicateToKeep_ValueChanged(object sender, EventArgs e) {
            UserSettings.Default.duplicatePokemonToKeep = (int) duplicateToKeep.Value;
            UserSettings.Default.Save();
        }

        private void evolveAboveCp_ValueChanged(object sender, EventArgs e)
        {
            UserSettings.Default.evolveAboveCp = (int)evolveAboveCp.Value;
            UserSettings.Default.Save();
        }
    }
}