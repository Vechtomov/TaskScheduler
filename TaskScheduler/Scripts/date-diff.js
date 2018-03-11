function GetDifference(date1, date2) {
    var minute = 60 * 1000;
    var hour = minute * 60;
    var day = hour * 24;
    var month = day * 30;

    var result = "";

    var date3 = date1 - date2;
    if (date3 < 0) {
        date3 = -date3;
    }

    var diffMonths = Math.floor((date3 / month));
    if (diffMonths > 0) {
        result += diffMonths + " месяцев ";
        date3 -= diffMonths * month;
    }

    var diffDays = Math.floor((date3 / day));
    if (diffDays > 0) {
        result += diffDays + " дней ";
        date3 -= diffDays * day;
    }

    var diffHours = Math.floor((date3 / hour));
    if (diffHours > 0) {
        result += diffHours + " часов ";
        date3 -= diffHours * hour;
    }

    var diffMinutes = Math.floor((date3 / minute));
    if (diffHours > 0) {
        result += diffMinutes + " минут";
        date3 -= diffMinutes * minute;
    }

    return result;
}