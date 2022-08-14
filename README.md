# UE_Spice_Demo
This is a demo project for the Spice plugin for [Unreal Engine](https://www.unrealengine.com). The plugin utilizes [ngspice](https://ngspice.sourceforge.io/) - the spice simulator for electric and electronic circuits.

## Table of contents
* [Build demo project](#build-demo-project)
* [Demo project tutorial](#demo-project-tutorial)
* [Blueprints tutorial](#blueprints-tutorial)
* [License](#license)

## Build demo project
1. Download the demo project

![image](https://i.imgur.com/zGo7Soh.png)

2. Create a Plugins folder

![image](https://i.imgur.com/lIf9K0M.png)

3. Add the plugin to the Plugins folder

![image](https://i.imgur.com/Srvmf49.png)

4. Open the ElectronicCircuit.uproject

![image](https://i.imgur.com/flSHs1U.png)

5. Rebuild the project

![image](https://i.imgur.com/trg3tkL.png)

6. Unreal Engine Editor opens.

![image](https://i.imgur.com/WxxYVYe.png)

## Demo project tutorial
[Video demonstration](https://youtu.be/dlcTaUPAE0g)

The demo project is made using Widget Blueprints.

The main widget is divided into 4 panels:
1. example circuits panel
2. input panel
3. output panel
4. graph panel

![image](https://i.imgur.com/xSlKuWI.png)

Click on any button from the example circuits panel to load the netlist and start the analysis.

![image](https://i.imgur.com/gnQZKWi.png)

Users can also type the netlist in the input panel and start the analysis with the start button.

![image](https://i.imgur.com/tFgcALZ.png)

The output text from ngspice is set in the output panel and the graph is shown in the graph panel.

![image](https://i.imgur.com/B1GlR2q.png)

The clear button clears the analysis data.

![image](https://i.imgur.com/eYpa9CP.png)

To control the graph panel, click and drag to move and scroll the mouse wheel to zoom in or out to the mouse position. If the analysis data is present, users can mouse over the graph to inspect specific values of the analysis.

![image](https://i.imgur.com/9oQ0FmD.png)

Users can change the vectors for the X and Y axes using the comboboxes and toggle the display of real and imaginary values in the controls on the right of the graph panel.

![image](https://i.imgur.com/9xDY8uW.png)

## Blueprints tutorial
To communicate with ngspice, construct an NgspiceCircuit.

![image](https://i.imgur.com/fgRiYvh.png)

To send a netlist to ngspice for analysis, use the StartAnalysis function and provide the netlist. The analysis starts in the background thread of ngspice and can be stopped using the StopAnalysis function. Ngspice can solve only one circuit at a time. In case there are more than one, they are scheduled for ngspice to start one by one.

![image](https://i.imgur.com/0IUvBns.png)

You can bind an event to the delegate that is called when the analysis finishes.

![image](https://i.imgur.com/29BVGVu.png)

There is no event to be called from the circuit when new data is calculated by ngspice, because it would fire too many times per tick and slow down the Main Thread. To get data during the analysis up to that point, the tick event together with the IsAnalysing function should be used.

![image](https://i.imgur.com/ftbI4kA.png)

Output from ngspice consists of StdOutput (an Array of Strings) and Analysis Values (a Map of Vector2D Arrays). StdOutput can be retrieved using the GetStdOutput function. Keys to the map of Analysis Values can be retrieved using the GetAnalysisValueKeys function. Each key is an input to the GetAnalysisValues function to get the array of values for the particular vector. Each value is a Vector2D to represent the real and imaginary parts.

![image](https://i.imgur.com/5F43acG.png)

The vectors can be cleared using the ClearStdOutput and ClearAnalysisValues functions. They are also cleared at the start of the analysis.

![image](https://i.imgur.com/6zY949Q.png)

Additional C++ functions are exposed for Blueprints to allow more performant manipulation with arrays and to simplify data for displaying on graphs.

![image](https://i.imgur.com/LMaI7US.png)

# License
Ngspice is open source under the [BSD-3-Clause license](https://ngspice.sourceforge.io/devel.html).
