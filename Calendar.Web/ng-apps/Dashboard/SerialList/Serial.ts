module SerialList {
    export class Serial {
        private _alias: string;
        private _name: string;

        constructor(alias: string, name: string) {
            this._alias = alias;
            this._name = name;
        }

        get Alias(): string {
            return this._alias;
        }

        get Name(): string {
            return this._name;
        }
    }
}