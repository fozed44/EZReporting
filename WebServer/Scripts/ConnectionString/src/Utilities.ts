
export
namespace Utilities {

    let log: (msg: string) => void 
        typeof window.console.log === 'function'
            ? function (msg: string) { console.log(msg); }
            : function (msg: string) { alert(msg); };

    export function assert(predicate: boolean, message: string = '') {
        if (!predicate)
            throw new Error(message || "Assertion Failed!");
    }

    export function logIfNot(predicate: boolean, message: string = '') {
        if (predicate) return;
        log(message || "Assertion Failed!\n" + (new Error).stack);
    }
}