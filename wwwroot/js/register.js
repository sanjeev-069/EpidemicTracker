const uri = 'http://localhost:61567/Login';
function addItem() {
    const addNameTextbox = document.getElementById('name');
    const addGenderTextbox = GetGender();
    const addEmailTextbox = document.getElementById('email');
    const addPhoneTextbox = document.getElementById('phone');
    const addPasswordTextbox = document.getElementById('pwd');
    const addRoleTextbox = document.getElementById('role')




    const item =
    {
        name: addNameTextbox.value.trim(),
        gender: addGenderTextbox,
        email: addEmailTextbox.value.trim(),
        phonenumber: addPhoneTextbox.value.trim(),
        password: addPasswordTextbox.value.trim(),
        roleid: parseInt(addRoleTextbox.value.trim())

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
        //.then(response => response.json())
        .then((item) => {
            console.log('Success', item);
        })
        .then(alert("Registration Successful..!  Please Login."))
    window.location.href ='http://localhost:61567/SignIn'
        .catch(error => console.error('Unable to add item.', error));

}



function GetGender() {
    var g = document.getElementById("gender");
    var getgender = g.options[g.selectedIndex].text;
    document.getElementsByClassName("custom").innerHTML = getgender;
    return getgender;
}

(function () {
    getRoles()

})();

function getRoles() {
    const url = 'http://localhost:61567/Role';
    fetch(url,
        {
            method: 'GET',
            headers:
            {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify()
        })
        .then(function (res) {
            return res.json();
        })
        .then(function (data) {
            let result = `<option value="">--Select--</option>`;
            data.forEach((role) => {
                result +=
                    '<option value="' + role['roleId'] + '">' + role['roleName'] + '</option>';
                document.getElementById('role').innerHTML = result;
            });
        })
        .catch(error => console.error('Unable to load roles.', error));
}





