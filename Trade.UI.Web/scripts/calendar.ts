/// <reference path="../node_modules/@types/jquery/index.d.ts" />
/// <reference path="../node_modules/@types/fullcalendar/index.d.ts" />

class Calendar {
    element: JQuery;
    monthEvents: string;
    date: string;

    constructor(element: JQuery, monthEvents: string, date: string) {
        this.element = element;
        this.monthEvents = monthEvents;
        this.date = date;
    }

    create() {
        this.element.fullCalendar({
            header: {
                left: "prev,next",
                center: "",
                right: ""
            },
            defaultDate:　this.date,
            editable: false,
            theme: false,
            displayEventTime: false,
            events: this.monthEvents,
            eventClick: function (event) {
                if (event.url) {
                    window.location.href = event.url
                }
            }
        });
    }
}

function createCalendar(element: JQuery, monthEvents: string, date: string) {
    const calendar = new Calendar(element, monthEvents, date);
    calendar.create();
}
