<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HelpOeeControl_de.ascx.cs" Inherits="M2M.DataCenter.WebUI.Help.HelpOeeControl_de" %>
<div>

   <h3><span style="color: #000000;">OEE</span></h3>

    <div title="Seite 3">

    <div>

    <div>



    OEE steht für Overall Equipment Effectiveness [Gesamtanlageneffektivität] und ist in drei Teile unterteilt; Verfügbarkeit, Leistung und Qualität. <ul>

	    <li><span>Die Verfügbarkeit (V) zeigt, über welchen Teil der geplanten Produktionszeit die Maschine tatsächlich produktiv ist. Die übrige Zeit wird als Ausfallzeit oder Verlust der Verfügbarkeit angesehen.</span></li>

	    <li><span>Die Leistung (L) zeigt an, bei welcher Geschwindigkeit die Maschine produziert, im Verhältnis zur idealen Geschwindigkeit der Maschine. Wenn die Geschwindigkeit der Produktion der Maschine langsamer ist, als die ideale Geschwindigkeit, wird das Leistungsverlust genannt.</span></li>

	    <li><span>Qualität (Q) zeigt an, wie viele Produkteinheiten nicht ausgestoßen werden. Die ausgestoßenen Einheiten gelten als Qualitätsverlust.</span></li>

	    <li><span>Ein Verlust der Verfügbarkeit (VV) zeigt, wie viel der geplanten Produktionszeit einer Maschine Ausfallzeit ist. Alle Stopps eingeschlossen.</span></li>

        <li><span>Verlust der Verfügbarkeit, Flussverlust (VVf), zeigt den Teil der Ausfallzeit auf einer Maschine an, der von Flussfehlern verursacht wird. Ein Flussfehler kann beispielsweise auftreten, wenn es in einer Linie eine Warteschlange gibt. Die Station, welche die Ausfallzeit verursacht, hat die Ausfallzeit als tatsächlichen Stopp gespeichert, während die übrigen Stationen, die aufgrund dieses Stopps anhalten, die Stoppzeit als Flussfehler gespeichert haben.</span></li>

        <li><span>Verlust der Verfügbarkeit, tatsächliche Stopps (VVt), zeigt den Teil der Ausfallzeit auf einer Maschine an, der von tatsächlichen Stopps verursacht wird. Tatsächliche Stopps umfassen alle Ausfallzeiten, die von einer Maschine/Station verursacht werden. Dieser Wert ist der interessanteste Wert, wenn Sie identifizieren möchten, wo Verbesserungsmaßnahmen anzusetzen sind.</span></li>

    </ul> &nbsp;



    </div>

    </div>

    </div>

    <div title="Seite 8">



        Beispiel: <ul>

	    <li><span>Verfügbarkeit (V): 51,64 % bedeutet, dass sich die Maschine etwas mehr als die Hälfte der geplanten Produktionszeit in einem produzierenden Zustand befand. Die Maschine muss ihre Zyklen kontinuierlich durchlaufen, damit sie als im produzierenden Zustand gilt. Die übrige Zeit wird als Ausfallzeit oder Verlust der Verfügbarkeit angesehen.</span></li>

	    <li><span>Leistung (L): 90,49 % bedeutet, dass die tatsächliche Geschwindigkeit der Maschine ca. 90 % der idealen Geschwindigkeit beträgt. Die ideale Geschwindigkeit kann davon abhängen, auf welchem Werkzeug die Maschine läuft. Der lokale Systemadministrator kann für jedes Werkzeug eine individuelle ideale Geschwindigkeit einstellen. Wenn für ein Werkzeug kein Wert eingestellt ist, wird die ideale Geschwindigkeit der Maschine für Vergleichszwecke genutzt. Wenn der Leistungswert höher als 100% ist, ist der Wert für die ideale Geschwindigkeit zu niedrig. Eine Maschine kann niemals eine Geschwindigkeit aufweisen, die schneller ist als die ideale Geschwindigkeit. Es ist nicht immer die beste Lösung, die Geschwindigkeit zu erreichen um einen höheren Leistungswert zu erzielen, da sich dies sowohl auf die Verfügbarkeit als auch auf die Qualität negativ auswirken kann.</span></li>

	    <li><span>Qualität (Q): 99,99 % bedeutet, dass im Wesentlichen alle produzierten Einheiten anerkannt wurden. Nicht alle Maschinen bieten dem System Informationen hinsichtlich der ausgestoßenen Einheiten. In diesem Fall beläuft sich der Wert der Qualität auf 100 %.</span></li>

	    <li><span>OEE: 46,73 % ist der zusammengesetzte Wert aus dem Vorstehenden und sagt aus, dass die Maschine eine Leistung von etwas weniger als der Hälfte ihrer Kapazität erbracht hat. Dieser Wert sagt aus, wie gut die Leistung der Maschine tatsächlich ist. Der Wert ist das Produkt der Eingangsfaktoren: &nbsp; <em>Verfügbarkeit * Leistung * Qualität = OEE</em></span></li>

    <li><span>Verlust der Verfügbarkeit (VV): 48,36 % ist die gesamte Ausfallzeit und hat folgenden Bezug: &nbsp; <em>Geplante Produktionszeit - Verfügbarkeit = Verlust der Verfügbarkeit</em></span></li>

    <li><span>Verlust der Verfügbarkeit, Flussfehler (VVf): 30,18 % ist die Ausfallzeit, die von Flussfehlern verursacht wurde, d.h. Warteschlangen in einer Linie. Diese Ausfallzeit wird im System als Status gespeichert. Hier wird deutlich, dass in diesem Fall der größte Teil der Ausfallzeit von Flussfehlern hervorgerufen wird.</span></li>

      <li><span>Verlust der Verfügbarkeit, tatsächliche Stopps (VVt): 18,18 % ist die Ausfallzeit, die von den tatsächlichen Stopps der Maschine hervorgerufen wird und den folgenden Bezug hat: &nbsp; <em>Verlust der Verfügbarkeit - Verlust der Verfügbarkeit, Flussfehler = Verlust der Verfügbarkeit, tatsächliche Stopps</em></span></li>

    </ul>

    </div>



</div>