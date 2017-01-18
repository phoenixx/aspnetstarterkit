let Utils = {};

Utils.splitCamelCase = (input) => {
    return input.replace(/([a-z])([A-Z])/g, '$1 $2');;
}

Utils.formatConsignmentAddress = (address) => {
    return `${address.contact.title} ${address.contact.firstName} ${address.contact.lastName}, ${address.addressLine1}, ${address.town}, ${address.postcode}, ${address.country.isoCode.twoLetterCode}`;
}

Utils.setNestedPropertyValue = (state, parentName, objName, obj) => {
    debugger;

    //if parentName contains dot, split on dot
    let split = parentName.split('.');
    const originalSplit = [...split];

    const splitLength = split.length;

    if (splitLength > 1) {
        split.push(objName);
        setNestedValue(state, split, obj);
        parentName = originalSplit[0];
        const result = state[parentName];
        return result;
    } else {
        const result = state[parentName];
        result[objName] = obj;
        return result;    
    }
}

//get an object reference by string e.g. address.contact.forename
Utils.objectByString = (obj, str) => {
    str = str.replace(/\[(\w+)\]/g, '.$1'); //convert index to prop
    str = str.replace(/^\./, ''); //strip leading dot
    const a = str.split('.');
    for (let i = 0, n = a.length; i < n; ++i) {
        const k = a[i];
        if (isObject(obj) && k in obj) {
            obj = obj[k];
        } else {
            return;
        }
    }
    return obj;
}

const isObject = (obj) => {
    return obj === Object(obj);
}

const setNestedValue = (obj, parts, value) => {
    if (!parts) {
        throw 'parts cannot be null';
    }

    if (parts.length === 0) {
        throw 'parts should not have zero length';
    }

    if (parts.length === 1) {
        obj[parts[0]] = value;
    } else {
        const next = parts.shift();
        if (!obj[next]) {
            obj[next] = {};
        }
        //recurse...
        setNestedValue(obj[next], parts, value);
    }
}

export default Utils;