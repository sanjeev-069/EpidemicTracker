const uri = 'http://localhost:61567/Patient';
function addPatient() {
    const addNameTextbox = document.getElementById('name');
    const addAgeTextbox = document.getElementById('age');
    const addGenderTextbox = GetGender();
    const addUniqueIdTextbox = GetIdType();
    const addUniqueIdNoTextbox = document.getElementById('id_no');
    const addPhoneTextbox = document.getElementById('phone');
    const addStreetTextbox = document.getElementById('street');
    const addAreaTextbox = document.getElementById('area');
    const addCityTextbox = document.getElementById('city');
    const addStateTextbox = document.getElementById('state');
    const addCountryTextbox = document.getElementById('country');
    const addZipCodeTextbox = document.getElementById('zip_code');



    const item =
    {
        patientname: addNameTextbox.value.trim(),
        age: parseInt(addAgeTextbox.value),
        gender: addGenderTextbox,
        uniqueidtype: addUniqueIdTextbox,
        uniqueidnumber: addUniqueIdNoTextbox.value,
        phonenumber: addPhoneTextbox.value.trim(),
        streetNumber: addStreetTextbox.value.trim(),
        area: addAreaTextbox.value.trim(),
        city: addCityTextbox.value.trim(),
        state: addStateTextbox.value.trim(),
        country: addCountryTextbox.value.trim(),
        zipcode: addZipCodeTextbox.value.trim(),
        loginid: parseInt(passValue())
    };
    fetch(uri,
        {
            method: 'POST',
            headers:
            {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(item)
        })
        .then(function (response) {
            if (response.status == 200) {
                window.location.href = 'http://localhost:61567/occupation.html';
            }
            return response.json()
        })
        .then((item) => {
            console.log(item);
            let patientid = item;
            localStorage.setItem("patientid", patientid);
            console.log(localStorage);
            localStorage.getItem("patientid");
        })

        .catch(error => console.error('Unable to add item.', error));

}



function GetGender() {
    var g = document.getElementById("gender");
    var getgender = g.options[g.selectedIndex].text;
    document.getElementsByClassName("custom").innerHTML = getgender;
    return getgender;
}

function GetIdType() {
    var g = document.getElementById("id");
    var getid = g.options[g.selectedIndex].text;
    document.getElementsByClassName("unique_id").innerHTML = getid;
    return getid;
}

function passValue() {
    var loginid = localStorage.getItem("loginid");
    return loginid;
}

$(function () {
    $("#header").load("header.html");
    $("#footer").load("footer.html");
});
 