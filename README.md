1. Introduction

The Smart Home Energy System (SHES) is a simulation platform designed to model, manage, and optimize household energy usage. 
It integrates solar panels, batteries, consumers, utility (electric grid), and an electric vehicle charger into a single system. 
The purpose of SHES is to ensure stable operation and cost efficiency by simulating real-world conditions and interactions.

2. Objectives

 - Simulate energy generation, storage, consumption, and utility interaction.
 - Implement optimal energy usage strategies (battery charging/discharging).
 - Provide real-time and accelerated-time simulations.
 - Enable user input for weather conditions, consumers, and simulation control.
 - Store all operational data and generate daily reports with cost analysis.

3. System Architecture

3.1 Components

 - Solar Panels – Generate energy proportional to sunlight intensity.
 - Battery – Stores or releases energy depending on time and demand.
 - Consumers – Use energy dynamically, can be turned on/off.
 - Utility – Provides/sells energy depending on surplus or shortage.
 - EV Charger – Simulates electric vehicle charging demand.

3.2 SHES Core

 - Central controller for monitoring and coordination.
 - Sends commands (charge/discharge, power allocation).
 - Collects data from all devices every second.
 - Stores information in a database.
 - Produces daily reports (charts + total cost).

4. Functional Requirements

 1. Solar panel management
   - Define panels by name and max power.
   - Generate energy based on sunlight input.
 2. Battery management
   - Define batteries by name, max power, and capacity.
   - Charge from 03:00–06:00, discharge from 14:00–17:00.
   - Report capacity and mode (charging/discharging).
 3. Consumers
   - Multiple consumers with unique names and consumption values.
   - Ability to switch consumers on/off.
 4. Utility interaction
   - Import/export electricity based on surplus/deficit.
   - Get/set energy price per kWh.
 5. System reports
   - Generate daily charts showing:
     - Solar production
     - Battery activity
     - Utility import/export
     - Consumer consumption
     - Calculate daily cost.
 6. Simulation control
   - Configurable time (accelerated simulation).
   - Separate XML configuration file for system setup.

5. Non-Functional Requirements

 - Usability – Console/UI for sunlight and consumer control.
 - Performance – Ability to simulate a full day in 10–20 minutes.
 - Scalability – Support multiple panels, batteries, and consumers.
 - Reliability – Ensure consistent state updates every second.
 - Maintainability – Code structured with modular architecture.

6. Development Methodology

 - Scrum framework used for iterative development.
 - Defined User Stories, sprint planning, and task estimation.
 - CI/CD pipeline with:
   - Automated builds
   - Unit testing
   - Code coverage analysis

7. Implementation Details

Language & Framework: C#, .NET Framework
UI: Console application.
Communication: Internal messaging between SHES and components (threading).
Config: XML-based configuration file.

8. Testing

 - Unit tests for each component (solar panel, battery, utility, consumer).
 - Integration tests for SHES coordination logic.
 - Performance tests for accelerated-time simulation.
 - CI cycle ensures test execution on each build.

9. Evaluation Criteria

 1. System design and architecture quality.
 2. Use of Scrum methodology.
 3. Functional completeness of the implementation.
 4. CI/CD pipeline success (build, tests, coverage).

10. Conclusion

The SHES project demonstrates how smart home energy management can be modeled, optimized, and evaluated. 
By simulating solar generation, battery storage, consumption, and utility interaction, SHES provides a testbed for exploring cost-saving strategies and sustainable household energy practices.
