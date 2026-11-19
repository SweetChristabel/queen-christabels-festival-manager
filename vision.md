# Pharaoh Festival Manager — Vision Notes

## Goal

Create an autoclicker-style mod for *Pharaoh: A New Era* that organises and launches festivals automatically.

The main purpose is to remove the repetitive manual work of organising festivals, especially when the game is running at 5× speed. The mod should automate the existing festival mechanic, with a few additional decision-making features.

## Scenario setup: create a yearly schedule

When a scenario starts:

1. Determine how many deities are available in the city.
2. Select a predefined yearly schedule based on that number.
3. Distribute the available deities across the scheduled festival months.

There are only five possible numbers of deities, so the schedules can initially be hard-coded.

Example: a city with two deities could hold festivals in April and October. The available deities would be assigned to those dates.

### Festival preparation time

Preparing a festival takes approximately two months, regardless of festival size.

The schedule must account for this lead time: preparation should begin early enough for the festival to take place in its intended month.

### Possible future extension: schedule overrides

A future feature could allow a deity's scheduled festival to be overridden if that deity becomes particularly unhappy (*pissed*).

## Festival execution

For each scheduled festival:

1. Decide how large the festival should be, based on the city's available money and beer.
2. Prepare the festival..

### Festival size

The initial implementation should select festival size using current money and beer availability.

Possible future improvements:

- Consider whether the city is gaining or losing money.
- Consider beer consumption and expected future availability.
- Use resource trends when deciding how large a festival the city can afford.

## Initial scope

The first version should focus on:

- Detecting the available deities at scenario start.
- Creating a yearly schedule based on the number of deities.
- Accounting for the two-month preparation period.
- Selecting a festival size based on available money and beer.
- Preparing and launching each scheduled festival automatically.

More advanced scheduling overrides and resource-trend analysis can be added later.
