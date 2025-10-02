<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HelpOeeControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Help.HelpOeeControl" %>
<div>
   <h3><span style="color: #000000;">OEE</span></h3>
    <div title="Page 3">
    <div>
    <div>

    OEE stands for Overall Equipment Effectiveness and is divided into three parts; Availability, Performance and Quality.
    <ul>
	    <li><span>Availability (A) shows how much of the planned production time a machine really is productive. All other time is considered as downtime or loss in availability.</span></li>
	    <li><span>Performance (P) shows at which pace a machine is producing in relation to the machines ideal pace. When a machine is producing slower than the ideal pace, we call that loss in performance.</span></li>
	    <li><span>Quality (Q) shows how many of the produced units not being discarded. The discarded units are considered as loss in quality.</span></li>
	    <li><span>Loss in availability (L) shows how much of the planned production time a machine has downtime. All 
            stops included.</span></li>
        <li><span>Loss in availability, flow error (Lf) shows the part of the downtime on a 
            machine that is caused by flow errors. A flow error can for example occur when 
            there is a queue in a line. The station that causes the downtime will have its 
            downtime stored as an actual stop, while the other stations that stops because 
            of that stop will have its stop time stored as flow error.</span></li>
        <li><span>Loss in availability, actual stops (Ls) shows the part of the downtime on a 
            machine that is caused by actual stops. All downtime that is caused by a 
            machine/station is considered as actual stops. This value is the most 
            interesting one when you want to identify where to set in actions for 
            improvements.</span></li>
    </ul>
    &nbsp;

    </div>
    </div>
    </div>
    <div title="Page 8">

        Example: 
    <ul>
	    <li><span>Availability (A): 51,64 % means that the machine has been in producing state 
            slightly more than half the planned production time. The machine must 
            continuously run its cycles to be considered to be in producing state. All other 
            time is considered as downtime or loss in availability.</span></li>
	    <li><span>Performance (P): 90,49 % means that the actual pace of the machine has been 
            approximately 90 % of the ideal pace. The ideal pace can depend on which tool 
            the machine is running. The local system administrator can set individual ideal 
            pace for each tool. If no value is set for a tool the machines ideal pace is 
            used for comparison. If the Performance value is greater than 100% is the value 
            for ideal pace to low. A machine can never have a pace that is faster than the 
            ideal pace. It is not always the best solution to gain the pace to reach a 
            higher Performance value, since this can affect both the Availability and the 
            Quality in a negative manner.</span></li>
	    <li><span>Quality (Q): 99,99% means that in essence all produced units have been approved. 
            Not all machines give the system information of discarded units. In these case 
            the value for Quality is 100%.</span></li>
	    <li><span>OEE: 46,73 % is the compound value of the above and tells us that the machine 
            has performed a bit less than half its capacity. This value tells us how well 
            the machine performs in reality. The value is the product of the ingoing factors:
    &nbsp;
    <em>Availability * Performance * Quality = OEEE</em></span></li>
    <li><span>Loss in availability (L): 48,36 % is the total downtime and have the following 
        relation:
    &nbsp;
    <em>Planned production time - Availability = Loss in availability</em></span></li>
    <li><span>Loss in availability, flow error (Lf): 30,18 % is the downtime that has been 
        caused by flow errors, ie queues in a line. This downtime is stored as a state 
        in the system. Here we can see that in this case the greater part of the 
        downtime is due to flow errors.</span></li>
      <li><span>Loss in availability, actual stops (Ls): 18,18 % 
            is the downtime caused by the actual stops in the machine and has the following 
            relation:
    &nbsp; 
    <em>Loss in availability - Loss in availability, flow error = Loss in availability, 
            actual stops</em></span></li>
    </ul>
    </div>

</div>