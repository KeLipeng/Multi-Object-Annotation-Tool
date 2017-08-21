# Multi-Object-Annotation-Tool
This tool is designed for multi-object annotation, which is used by UA-DETRAC dataset annotaion.
Usage:
  1. When Click Save button, current process will be saved under the Openfile path with 3 file ：FileName_Config.txt(Configure file for reload)、FileName_RoI.txt(RoI/IgnoreRegion information)、FileName.txt(Target label information File)。
  2. Click Load button to continue labeling from a saved labeling process。
  3. You might preview your labeling, fast forward/rewind with the play button.

TargetLableTool_V4
[1]	Start the Tool；

[2]	Ignore Region: Choose the sequence path and the draw the Ignore Region with Draw button and End the Ignore Region Drawing by click the End button. 

[3]	Labeling: After defining the ignore region, we could start labeling the target at the first frame. Press left mouse button and draw a boundingbox then release the mouse to label a target. Also you might modify/Delete/Insert an annotation with Modify/Delete/Insert button, and remember to click End button under Modify button after the modification. When you finish a frame, click Next button to label the next frame.
From the second frame, you could specify ID to target by, A. click the corresponding target in the left window, B. input ID in the textbox under the Start button and click Enter.

[4]	Saving: Click Save button to save your current process. You might want to save regularly to back up your work.


