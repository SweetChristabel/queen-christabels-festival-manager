# Queen Christabel's Festival Manager


Automatically organise religious festivals in **Pharaoh: A New Era**, a 2023 remake of a 1999 classic.

Anyone who knows me knows how passionately I despise mindless, repetitive button pressing.
This long time favourite game of mine has a feature that demands a lot of it, so I decided to do something about it.
The mod schedules festivals throughout the year, rotates between the active deities, and selects the largest festival your city can reasonably afford.

## Features

-   Kicks in when a certain (configurable, default 1000) population is reached and a festival square built
-   Automatically schedules festivals based on the number of active deities, spread throughout the calendar year
-   Attempts to prepare one festival per god per year, or two per year if only one god is available
-   Selects between Small, Lavish and Grand Festivals based on available resources.
        Grand Festivals can be turned off in the config file, and resource thresholds can be adjusted
-   Skips if you've already organised a festival manually or if requirements are not met
-   Configurable through the BepInEx configuration file

## Requirements

-   Pharaoh: A New Era
-   BepInEx 5.4.23.6

## Installation

1.  Make sure BepInEx is installed and working
2.  Download `PharaohFestivalManager.dll`, nothing else.
3.  Place the DLL in your game's `BepInEx/plugins` folder
4.  Launch the game

5.  Or, alternatively, go ahead and compile it yourself from the PharaohFestivalManager folder.

## Activation and behaviour

The mod will only organise festivals when the configured minimum population has been reached, and a festival square built.
This helps prevent festivals from consuming resources too early in a city's development.

The mod checks whether a festival's cost falls within your configured resource
limits before organising it. If no festival size is affordable, or a festival has already been prepared by the player,
that scheduled festival is skipped and the mod will continue to follow the schedule, meaning that the same festival will not be retried until same time next year.


## Configuration

The configuration file is generated automatically by BepInEx after the game is launched once:

`BepInEx/config/com.pharaohfestivalmanager.main.cfg`

You can edit this file with any text editor. Changes take effect when
the game is restarted.

Available settings:

| Setting | Default | Description |
|---|---:|---|
| `ModEnabled` | `true` | Enables or disables automatic festival management. |
| `GrandFestivalsEnabled` | `true` | Allows the mod to organise Grand Festivals. |
| `TreasuryLimit` | `0.25` | Maximum proportion of the current treasury that a festival may cost. |
| `BeerLimit` | `0.50` | Maximum proportion of stored beer that a Grand Festival may consume. |
| `MinimumPopulation` | `1000` | Minimum population required for automatic festival management. |


Percentage limits are expressed as fractions: `0.25` means 25%, and
`0.50` means 50%.




## What's next?

I'm working on a GUI implementation for in-game configuration and statistics.

## Version history

### 1.0.0

Initial public release.
