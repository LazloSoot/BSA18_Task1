import { Fighter } from "./fighter"

class ImprovedFighter extends Fighter {
    constructor(name, power, health) {
        super(name, power, health);
        this._type = "ImprovedFighter";
    }
    
    Hit(enemy, point)
    {
        this.DoubleHit(enemy, point);
    }
    
    DoubleHit(enemy, point)
    {
        console.log(`${this.Name} double hitted ${enemy.Name}`);
        super.Hit(enemy, point * 2);
    }
}


export { ImprovedFighter };