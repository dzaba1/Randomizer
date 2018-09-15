import { Require } from '../../utils/require';
import { CookieService } from 'ngx-cookie-service';

export class CookieCache<T> {
    private _name: string;

    constructor(name: string,
        private cookies: CookieService) {
        Require.notEmptyString(name, 'name');
        this._name = name;
    }

    public get name(): string {
        return this._name;
    }

    public get isStored(): boolean {
        return this.cookies.check(this._name);
    }

    public save(data: T, expires: Date) {
        Require.notNull(data, 'data');
        Require.notNull(expires, 'expires');

        const json = JSON.stringify(data);
        this.cookies.set(this._name, json, expires);
    }

    public get(): T {
        if (!this.isStored) {
            return null;
        }

        const json = this.cookies.get(this._name);
        return JSON.parse(json);
    }

    public invalidate() {
        this.cookies.delete(this._name);
    }
}
