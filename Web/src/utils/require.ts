export module Require {
    export function notNull(obj: any, paramName: string) {
        if (obj == null) {
            throw new ReferenceError('The \'' + paramName + '\' is null or undefined.');
        }
    }
}
