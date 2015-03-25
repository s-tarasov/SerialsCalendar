/// <reference path="../../../Scripts/typings/angularjs/angular.d.ts"/>
/// <reference path="../../../Scripts/typings/es6-promise/es6-promise.d.ts"/>

module SerialList {
    interface IModel extends ng.IRootScopeService {
        serials: Serial[];
        newSerial: string;
        actions: SerialListController;
    }

    export class SerialListController {
        private _$scope: IModel;
        private _serialsProvider: SerialsProviderService;
        private _ready: boolean;
        constructor($scope: IModel, serialsProvider: SerialsProviderService) {
            this._$scope = $scope;
            this._serialsProvider = serialsProvider;

            $scope.actions = this;
            $scope.serials = [];
            serialsProvider.getAll()
                .then((serials) => {
                    $scope.serials = serials;
                    $scope.$apply();

                    this._ready = true;
                });
        }

        addSerial(serial: Serial) {
            if (this._ready) {
                this._$scope.serials.unshift(serial);
                this._$scope.newSerial = "";
                this._serialsProvider.add(serial);
            }
        }

        removeSerial(serial: Serial) {
            if (this._ready) {
                this._$scope.serials.splice(this._$scope.serials.indexOf(serial), 1);
                this._serialsProvider.remove(serial);
            }
        }

        getSerials(val) {
            return this._serialsProvider.findSerials(val);
        }
    };
}