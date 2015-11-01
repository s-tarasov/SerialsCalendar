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
            var sourceUrl = "//api.themoviedb.org/3/search/tv?api_key=fe5f5be42e7abbb3079056701867b87f&query="
                + encodeURIComponent(str);

             return this._$http.get<any>(sourceUrl)
                 .then((responce) => {
                    if (!responce.data.results) {
                        return [];
                    }

                    return responce.data.results
                        .map(r => r.name)
                        .map(r => new Serial(r, r));
                });
        }
    }
}