export class Plane{
    constructor(
        public id?: number,
        public Name?: string,
        public ReleaseDate?: Date,
        public LifeTime?: Date,
        public LastHeavyMaintence?: Date,
        public FlightHours?: number,
        public PlaneTypeId?: number
    ){}
}