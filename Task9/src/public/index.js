import { Fight } from "./fight";
import { Fighter } from "./fighter";
import {ImprovedFighter} from "./improvedFighter";

var fighter = new Fighter("Grisha");
var iFighter = new ImprovedFighter("Vasia", 15, 600);
iFighter.DoubleHit(fighter, 1);
Fight(fighter, iFighter, 1,2,3,4,5);

//document.getElementById("app").innerHTML = a;