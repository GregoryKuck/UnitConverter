var view = new Vue({
    el: '#main',
    data: {
        conversionUnits: [],
        conversion: {
            value: 0,
            from: 'Celsius',
            to: 'Fahrenheit'
        },
        conversionResponse: 0,
        conversionError: ""
    },
    computed: {
        conversionRequest: function () {
            return { valueToConvert: view.conversion.value, conversion: `${view.conversion.from}To${view.conversion.to}` };
        }
    },
    methods: {
        assignUnits: function (units) {
            view.conversionUnits = units.slice(0);
        },
        assignResponse: function (resp) {
            view.conversionResponse = resp;
        },
        getUnits: function () {
            this.serverCall('GET', '/api/conversion', null, view.assignUnits)
        },
        convert: function () {
            this.serverCall('POST', '/api/conversion', view.conversionRequest, view.assignResponse)
        },
        serverCall: function (method, destUrl, obj, callBack) {
            var jsonData = obj ? JSON.stringify(obj) : '';

            $.ajax({
                method: method,
                url: destUrl,
                dataType: 'json',
                contentType: 'application/json',
                data: jsonData,
                success: function (resp) {
                    view.conversionError = '';
                    callBack(resp);
                },
                error: function (xhr, status, error) {
                    view.conversionError = xhr.responseText;
                }
            });
        }
    }
});

$(document).ready(function () {
    view.getUnits();
});
