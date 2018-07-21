export { Fight };

async function Fight(firstFighter, secondFighter, ...point){
    try {
        if(firstFighter.Health <= 0 || secondFighter.Health <= 0)
            throw new Error(`Fighters not ready to fight!`);
        while(true)
        {
            await point.forEach((element)=> {
                if(firstFighter.Health <= 0)
                    {
                        firstFighter.Knockout();
                        throw new Error(`${firstFighter.Name}\`s health is out`);
                    }
                else
                    firstFighter.Hit(secondFighter, element);
                
                 if(secondFighter.Health <= 0)
                    {
                        secondFighter.Knockout();
                        throw new Error(`${secondFighter.Name}\`s health is out`);
                    }
                else
                    secondFighter.Hit(firstFighter, element);

                });
        }
    } catch(error) {
        console.log(error.message);
    }
}
