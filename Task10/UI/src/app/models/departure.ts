export class Departure {
    constructor(
        public id?: number,
        public FlightId?: number,
        public DepartureTime?: Date,
        public CrewId?: number,
        public PlaneId?: number
    ){}
}