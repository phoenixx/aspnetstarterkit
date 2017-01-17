let Utils = {};

Utils.splitCamelCase = (input) => {
    return input.replace(/([a-z])([A-Z])/g, '$1 $2');;
}

Utils.formatConsignmentAddress = (address) => {
    return `${address.contact.title} ${address.contact.firstName} ${address.contact.lastName}, ${address.addressLine1}, ${address.town}, ${address.postcode}, ${address.country.isoCode.twoLetterCode}`;
}

export default Utils;