 It is necessary to design the system, system architecture, implement, document, and test a solution that simulates the operation and communication of a Smart Home Energy System (SHES). 
 SHES is a system that manages the operation of the home energy system and ensures optimal and stable performance.
 The system contains 5 components:
 
 1 Solar panels
 2 Batteries
 3 Consumers
 4 Utility (electric distribution)
 5 Electric vehicle charger
 
 Solar Panels
 
 Solar panels produce electrical energy proportionally to weather conditions. A household system may include multiple solar panels.
 When adding a solar panel to the system, it is defined by the following parameters:
 • Unique name
 • Maximum power
 Once added, the solar panel starts generating electrical energy depending on solar radiation intensity:
 • 0% sunlight – 0% panel power
 • ....
 • 100% sunlight – 100% panel power
 The sunlight level is entered via UI (or console application) in a separate thread and can be changed at any time. 
 The power measurement of each solar panel is sent to SHES every second.
 
 Battery
 
 The battery stores electrical energy for optimal usage. 
 Optimal usage implies charging the battery when energy is cheap/consumption is low and discharging when energy is expensive/consumption is high.
 When adding a battery to the system, it is defined by the following parameters:
 • Unique name
 • Maximum power
 • Capacity (in hours of operation)
 SHES manages the battery as follows:
 • From 3h to 6h charging
 • From 14h to 17h discharging
 During charging and discharging, capacity in hours changes. 
 Each minute of discharge decreases capacity by one minute, each minute of charging increases capacity by on minute. 
 SHES communicates with the battery by sending charging/discharging commands. 
 The battery communicates back by sending its capacity and operating mode.
 When charging, it behaves as a consumer; when discharging, it behaves as an energy generator.

 Consumers
 
 Consumers in the system use electrical energy. 
 They can be turned on/off arbitrarily and there can be any number of them in the system.
 Each consumer is defined by:
 • Unique name
 • Consumption

 Utility (electric distribution)
 
 SHES obtains excess electricity from the utility. 
 The surplus is the difference between current consumption and current production. 
 The surplus is sent to the utility as an energy request, and the utility responds with a price per kWh.
 Interaction with the utility is defined as:
 • Exchange power (positive or negative)
 • Price
 
 SHES
 
 SHES is the central control system. 
 The goal of the system is optimal energy management and cost calculation.
 Operating costs:
 • Battery: 0 $/kWh
 • Solar panel: 0 $/kWh
 • Utility: X $/kWh
 SHES sends commands to batteries for charging/discharging and receives information about the current status of batteries, solar panels, and utility energy prices. 
 All this information is stored in a database. 
 SHES calculates a report for a selected date. 
 The report includes a chart with the following curves:
 • Solar panel production
 • Battery energy (positive and negative)
 • Utility import (positive and negative)
 • Total consumer consumption
 In addition to the chart, SHES calculates the total cost in $ for the selected date.
 
 Application Scenario
 
 At startup, communication with all system devices is initialized. 
 SHES calculates the required energy amount from the utility every second, which may be positive or negative. 
 A positive amount means cost for SHES since energy is imported at the given utility price ($/kWh). 
 A negative difference means the household system sells energy to the utility at the same price.
 System time should be separate from real time and should be configurable to run faster. 
 In the common XML configuration file for all applications, the relation between application seconds and real seconds is defined. 
 For example, one real second can equal X application seconds. 
 This enables simulation of a full day of system operation in 10–20 minutes.
 
 Evaluation Criteria
 
 1 System design and architecture
 2 Use of Scrum methodology – defining User Stories and tasks, planning and estimation
 3 Solution implementation
 4 CI cycle
   a. Build
   b. Unit tests
   c. Code coverage by tests
