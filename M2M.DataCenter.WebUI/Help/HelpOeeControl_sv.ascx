<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HelpOeeControl_sv.ascx.cs" Inherits="M2M.DataCenter.WebUI.Help.HelpOeeControl_sv" %>
<div>
   <h3><span style="color: #000000;">TAK (OEE)</span></h3>
    <div>
    <div>
    <div>

    TAK står för Tillgänglighet, Anläggningsutbyte och Kvalitetsutbyte. Internationellt används begreppet OEE (Overall Equipment Effectiveness).
    <ul>
	    <li><span>Tillgänglighet (T) visar hur stor del av den planerade produktionstiden som maskinen verkligen presterar. All övrig tid är stopptid och ses som tillgänglighetsförlust.</span></li>
	    <li><span>Anläggningsutbyte (A) visar vilket tempo maskinen presterar i förhållande till maskinens optimala tempo. När en maskin arbetar långsammare än optimalt talar man om hastighetsförlust.</span></li>
	    <li><span>Kvalitetsutbyte (K) visar hur andel av totalt producerade enheter som inte behöver kasseras. All kassation räknas som kvalitetsförlust.</span></li>
	    <li><span>Tillgänglighetsförlust (F) visar hur stor del av den planerade produktionstiden det har varit stopp. Alla stopp inkluderade.</span></li>
        <li><span>Tillgänglighetsförlust, flödesfel (Ff) visar den del av stopptiden för 
        en maskin/station som beror på flödesfel. Ett exempel på flödesfel är när det blir kö i en linje. Den 
        stationen som orsakar stoppet får stopptiden lagrad som faktiskt stopp, medan 
        övriga staioner som påverkas av stoppet får stoppet lagrat som flödesfel.</span></li>
        <li><span>Tillgänglighetsförlust, faktiska stopp (Fs) visar den del av stopptiden för 
        en maskin/station som beror på faktiska stopp. Som faktiska stopp räknas alla 
        stopp som beror på maskinen/stationen i sig till skillnad från stopp som beror 
        på flödesfel. Det är framförallt detta värde som är intressant när man vill se var man ska göra sina åtgärder.</span></li>
    </ul>
    &nbsp;

    </div>
    </div>
    </div>
    <div>

    Exempel:
    <ul>
	    <li><span>Tillgänglighet (T): 51,64 % betyder att maskinen varit i drift lite drygt hälften av den planerade produktionstiden. För att anses vara i drift måste maskinen kontinuerligt slå sina slag. All övrig tid räknas som stopptid eller tillgänglighetsförlust.</span></li>
	    <li><span>Anläggningsutbyte (A): 90,49 % betyder att maskinens takt varit ca 90 % av den ideala takten. Eftersom den ideala takten kan vara beroende på vilket verktyg som körs i maskinen kan den lokala systemadministratören ange ideal takt för varje enskilt verktyg. Finns inte en ideal takt angiven för verktyget används värdet för maskinens ideala takt som jämförelse. Får man värden över 100 % här innebär det att man ställt in en för låg ideal takt. En maskin kan aldrig prestera snabbare än den ideala takten. Att öka takten för att uppnå ett högre Anläggningsutbyte är inte alltid den rätta lösningen. Visserligen blir värdet högre, men det kan mycket väl påverka såväl Tillgängligheten som Kvaliteten i negativ riktning.</span></li>
	    <li><span>Kvalitet (K): 99,99% betyder att i princip alla enheter har varit godkända. Det har nästan inte varit någon kassation alls. Det kan vara bra att veta att inte alla maskiner ger systemet någon indikation om kassation. I de fallen visas värdet 100 %.</span></li>
	    <li><span>TAK/OEE: 46,73 % betyder att maskinen presterat en bit under hälften av sin kapacitet. Det är detta värdet som verkligen talar om hur väl maskinen presterar. Värdet beräknas som produkten av de ingående faktorerna:
    &nbsp;
    <em>Tillgänglighet * Anläggningsutbyte * Kvalitet = TAK/OEE</em></span></li>
    <li><span>Tillgänglighetsförlust (F): 48,36 % är den totala stopptiden för maskinen och 
        fås fram genom:
    &nbsp;
    <em>Planerad produktionstid - Tillgänglighet = Tillgänglighetsförlust</em></span></li>
    <li><span>Tillgänglighetsförlust, flödesfel (Ff): 30,18 % är den stopptiden som beror på flödesfel, tex köbildning i en linje. Stopptiden för flödesfel lagras hela tiden.
        Här kan vi se att flödesfel i detta fallet utgör den större delen av stopptiden.</span></li>
        <li><span>Tillgänglighetsförlust, faktiska stopp (Fs): 18,18 % är den faktiska stopptiden för maskinen och fås fram genom:
    &nbsp;
    <em>Tillgänglighetsförlust - Tillgänglighetsförlust, flödesfel = Tillgänglighetsförlust, faktiska stopp</em></span></li>
    </ul>
    </div>

</div>