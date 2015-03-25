/// <reference path='../../../Scripts/typings/angularjs/angular.d.ts'/>
/// <reference path="../../../Scripts/typings/es6-promise/es6-promise.d.ts"/>

module SerialList {
    export class SerialsProviderService {
        private _$http: ng.IHttpService;
        private _serials: Serial[];

        constructor($http: ng.IHttpService) {
            this._$http = $http;
            this._serials = [];
        }

        getAll(): Promise<Serial[]>{
            return this._$http.get<any>("/serials")
                .then((responce) => {
                    return responce.data
                        .map(r => new Serial(r.Title, r.Title));
                });
        }

        add(serial: Serial): Promise<any> {
            return this._$http.post("/serials", { SerialId: serial.Alias });
        }

        remove(serial: Serial): Promise<any> {
            return this._$http.delete<any>("/serials/" + serial.Alias);
        }

        findSerials(str): Promise<Serial[]>{
            var sourceUrl = "http://services.tvrage.com/feeds/search.php?key=285i2wboRoru1Z38syH3&show="
                + encodeURIComponent(str);

             return this._$http.get<any>(
                "//query.yahooapis.com/v1/public/yql?q="
                + encodeURIComponent("select show.name from xml where url='" + sourceUrl + "'")
                + "&format=json")
                .then((responce) => {
                    if (!responce.data.query.count) {
                        return [];
                    }

                    var results = responce.data.query.results.Results;
                    if (results.show) {
                        results = [results];
                    }

                    return results
                        .map(r => r.show.name)
                        .map(r => new Serial(r, r));
                });
        }
    }
}