# UE_Spice_Demo
This is a demo project for the Spice plugin for [Unreal Engine](https://www.unrealengine.com) available on the [marketplace](https://www.unrealengine.com/marketplace/en-US/product/20c869cbe45b4b999e677c1f22fa4381). The plugin utilizes [ngspice](https://ngspice.sourceforge.io/) - the spice simulator for electric and electronic circuits.

## Table of contents
* [Demo project tutorial](#demo-project-tutorial)
* [Blueprints tutorial](#blueprints-tutorial)
* [License](#license)

## Demo project tutorial
[Video demonstration](https://youtu.be/XACr_H5ea24)

The demo project is made using Widget Blueprints.

The main widget is divided into 5 panels:
1. examples
2. netlist
3. alter
4. output
5. graph

![image](https://i.imgur.com/NYOdVwp.png)

Click on any button from the example circuits to set the netlist or type the netlist in the netlist panel.

![image](https://i.imgur.com/Jx9jnXu.png)

Leave the checkbox unchecked to run the analysis until finished or check the checkbox and enter a number to run only a fixed number of time-points and then pause.

![image](https://i.imgur.com/vP7luyS.png)

Start the analysis with the start button.

![image](https://i.imgur.com/co6OpSe.png)

The output text from ngspice is set in the output panel and the graph is displayed in the graph panel.

![image](https://i.imgur.com/AByW6P7.png)

If the analysis is paused, type the instructions in the alter panel
to change the device or model parameters of the circuit.

![image](https://i.imgur.com/wukSXjv.png)

Leave the checkbox unchecked to run the analysis until finished or check the checkbox and enter a number to run only a fixed number of time-points and then pause again.

![image](https://i.imgur.com/aqy0Iwu.png)

Click the resume button to apply the changes and continue the analysis.

![image](https://i.imgur.com/KAdwgiN.png)

To control the graph panel, click and drag to move and scroll to zoom to the mouse position.
Hover over the graph to inspect specific values of the analysis.

![image](https://i.imgur.com/kri9A0l.png)

Use comboboxes to change the vectors for the X and Y axes and checkboxes to display the real and imaginary values.

![image](https://i.imgur.com/wHqXCVI.png)

The clear button clears the analysis data.

![image](https://i.imgur.com/twRseir.png)

## Blueprints tutorial
To communicate with ngspice, construct an NgspiceCircuit.

![image](https://i.imgur.com/MdUZm2o.png)

To start an analysis, use the StartAnalysis function and provide a netlist.
StepCount can be set to run only a fixed number of time-points and then pause or set (StepCount <= 0) to run until finish.
The analysis starts in the background thread of ngspice.

![image](https://i.imgur.com/daua56Q.png)

To request a pause or resume of an analysis, use the SetAnalysisShouldPause function.

![image](https://i.imgur.com/Qtzx6KY.png)

The state of the pause request is indicated by the ShouldPause function.

![image](https://i.imgur.com/bavDeBN.png)

To stop an analysis, use the StopAnalysis function.

![image](https://i.imgur.com/kbXKZLD.png)

The IsAnalysing function indicates the analysis of the circuit is in progress.
Ngspice can solve only one circuit at a time.
In case more than one circuit starts the analysis, they are scheduled for ngspice to start one by one.
Beware of paused analyses, the analysis of the next circuit cannot start while the previous one is paused.

![image](https://i.imgur.com/twEemmN.png)

AnalysisStartedDelegate fires when the background thread starts.
AnalysisPausedDelegate fires when the background thread pauses.
AnalysisFinishedDelegate fires when the background thread finishes.

![image](https://i.imgur.com/5JgOzoD.png)

The state of the background thread visible from the Game Thread can be obtained using the IsRunning function.
There is no event to be fired when new data is calculated by ngspice, because it would fire too many times per tick and slow down the Game Thread.
To get data during the analysis up to that point, the tick event together with the IsRunning function should be used.

![image](https://i.imgur.com/fX4jV8x.png)

To update an analysis, use the UpdateAnalysisWithAlter, UpdateAnalysisWithAltermod or UpdateAnalysisWithStepCount function.
The changes will be processed when the analysis starts or resumes.
To apply the changes if the analysis is running, restart it by pausing it with the SetAnalysisShouldPause and resuming it with the SetAnalysisShouldPause after the AnalysisPausedDelegate is called.

![image](https://i.imgur.com/dHL3XGu.png)

Output from ngspice consists of StdOutput (an Array of Strings) and Analysis Values (a Map of Vector2D Arrays).
StdOutput can be retrieved using the GetStdOutput function.
Keys to the map of Analysis Values can be retrieved using the GetAnalysisValueKeys function.
Each key is an input to the GetAnalysisValues function to get the array of values for the particular vector.
Each value is a Vector2D to represent the real and imaginary parts.

![image](https://i.imgur.com/YYQlSyh.png)

Output from ngspice can be removed or cleared using the ClearStdOutput, RemoveRangeStdOutput, ClearAnalysisValues and RemoveRangeAnalysisValues functions.
All outputs are also cleared at the start of the analysis.

![image](https://i.imgur.com/MctqJD8.png)

Additional C++ functions are exposed for Blueprints to allow more performant manipulation with arrays and to simplify data for displaying on graphs.

![image](https://i.imgur.com/C9xlzar.png)

# License
Ngspice is open source under the [3-clause BSD license](https://sourceforge.net/p/ngspice/ngspice/ci/master/tree/COPYING).
