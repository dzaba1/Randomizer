export module Require {
    export function notNull(obj: any, paramName: string) {
        if (obj == null) {
            throw new ReferenceError(`The parameter '${paramName}' is null or undefined.`);
        }
    }

    export function notEmptyString(str: string, paramName: string) {
        notNull(str, paramName);
        if (str.trim() === '') {
            throw new RangeError(`The parameter '${paramName}' is empty.`);
        }
    }
}
