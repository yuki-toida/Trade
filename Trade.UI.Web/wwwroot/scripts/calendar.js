/// <reference path="../node_modules/@types/jquery/index.d.ts" />
/// <reference path="../node_modules/@types/fullcalendar/index.d.ts" />
var Calendar = (function () {
    function Calendar(element, monthEvents, date) {
        this.element = element;
        this.monthEvents = monthEvents;
        this.date = date;
    }
    Calendar.prototype.create = function () {
        this.element.fullCalendar({
            header: {
                left: "prev,next",
                center: "",
                right: ""
            },
            defaultDate: this.date,
            editable: false,
            theme: false,
            displayEventTime: false,
            events: this.monthEvents,
            eventClick: function (event) {
                if (event.url) {
                    window.location.href = event.url;
                }
            }
        });
    };
    return Calendar;
}());
function createCalendar(element, monthEvents, date) {
    var calendar = new Calendar(element, monthEvents, date);
    calendar.create();
}
//# sourceMappingURL=calendar.js.map