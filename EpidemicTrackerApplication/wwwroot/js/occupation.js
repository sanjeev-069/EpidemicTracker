const uri = 'http://localhost:61567/Occupation';
function addOccupation() {
    const addNameTextbox = document.getElementById('name');
    const addPhoneTextbox = document.getElementById('phone');
    const addWorkTypeTextbox = GetWorkType();
    const addDesignationTextbox = document.getElementById('designation'); 
    const addStreetTextbox = document.getElementById('street');
    const addAreaTextbox = document.getElementById('area');
    const addCityTextbox = document.getElementById('city');
    const addStateTextbox = document.getElementById('state');
    const addCountryTextbox = document.getElementById('country');
    const addZipCodeTextbox = document.getElementById('zip_code');



    const item =
    {
        organisationname: addNameTextbox.value.trim(),
        phonenumber: addPhoneTextbox.value.trim(),
        worktype: addWorkTypeTextbox,
        designation: addDesignationTextbox.value.trim(),
        streetNumber: addStreetTextbox.value.trim(),
        area: addAreaTextbox.value.trim(),
        city: addCityTextbox.value.trim(),
        state: addStateTextbox.value.trim(),
        country: addCountryTextbox.value.trim(),
        zipcode: addZipCodeTextbox.value.trim(),
        patientid: parseInt(passPatient())
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
                window.location.href = 'http://localhost:61567/hospital.html';
            }
            return response.json()
        })
        .then((item) => {
            console.log('Success', item);
        })

        .catch(error => console.error('Unable to add occupation.', error));

}


function GetWorkType() {
    var g = document.getElementById("worktype");
    var getworktype = g.options[g.selectedIndex].text;
    document.getElementsByClassName("worktype").innerHTML = getworktype;
    return getworktype;
}

function passPatient() {
    var patientid= localStorage.getItem("patientid");
    return patientid;
}
$(function () {
    $("#header").load("header.html");
    $("#footer").load("footer.html");
});
