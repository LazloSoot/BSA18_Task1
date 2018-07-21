
class Fighter {
    constructor(name, power = 15, health = 150) {
        this.Name = name;
        this.Power = power;
        this.Health = health;
        this._type = "Fighter";
    }
    SetDamage(damage = 1) 
    {
        this.Health = this.Health - damage;
        console.log(this.Name + "`s Health:" + this.Health);
        return this.Name + "`s Health:" + this.Health;
    }
    
    Hit(enemy, point) 
    {
        if(this._type.localeCompare("Fighter") == 0)
            console.log(`${this.Name} hitted ${enemy.Name}`);
        var d = point * this.Power;
        enemy.SetDamage(d);
    }
    getClass(obj) {
  return {}.toString.call(obj).slice(8, -1);
    }
    
    Knockout() 
    {
        let result = new Promise((resolve, reject) => {
            setTimeout(() => {
                console.log("time is over");
                return resolve(`${this.Name} is knocked out!`);
            }, 500)
        });
        
        result
            .then(success => {
            console.log(success);
        })
        .catch(error => {
            console.log(error.message);
        });
    }
}



export { Fighter  };
