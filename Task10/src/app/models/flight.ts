export class Flight {
    constructor(
        public id?: number,
        public DeparturePoint?: string,
        public DepartureTime?: Date,
        public Destination?: string,
        public ArrivalTime?: Date,
        public TicketsIds?: number[]
    ) { }
}