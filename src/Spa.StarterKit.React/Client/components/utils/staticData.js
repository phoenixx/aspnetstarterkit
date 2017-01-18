﻿import axios from 'axios';

let StaticData = {};

StaticData.getCountries = () => {
    const url = '/data/countries';
    return axios.get(url).then((result) => {
        console.log(`data from ${url}`, result);
        return result.data.map((country) => {
            return { value: country.twoLetterIsoCode, label: country.name, postcodeRequired: country.postCodeRequired}
        });
    }).catch((error) => {
        console.log(error);
        return [];
    });
}

StaticData.getTitles = () => {
    const url = '/data/titles';
    return axios.get(url).then((result) => {
        console.log(`data from ${url}`, result);
        return result.data.map((title) => {
            return {
                value: title,
                label: title
            }
        });
    }).catch((error) => {
        console.log(error);
        return [];
    });
}

StaticData.getAssignedShippingLocations = () => {
    const url = '/data/shippinglocations/assigned';
    return axios.get(url).then((result) => {
        console.log('shipping locs: ', result.data);
        return result.data.map((loc) => {
            return {
                label: loc.name,
                value: loc.reference,
                location: loc
            }
        });
    });
}

export default StaticData;