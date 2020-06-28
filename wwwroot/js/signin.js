const uri = 'http://localhost:61567/Login/SignIn';
function validateLogin() {
    const addNameTextbox = document.getElementById('email');
    const addPasswordTextbox = document.getElementById('pwd');

    const item =
    {
        email: addNameTextbox.value.trim(),
        password: addPasswordTextbox.value.trim()
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
                
                window.location.href = 'http://localhost:61567/homepage.html';
                

                    

                   
            }
            else {
                alert("Invalid Username/Password...Please Try Again!");
            }
            

            return response.json()
        })
       
        .then((item) => {
             console.log(item);
            
            let loginid = item.loginId;
            let name = item.name;
            localStorage.setItem("loginid", loginid);
            localStorage.setItem("name", name);
            console.log(localStorage);
            localStorage.getItem("loginid");
        })
        .catch(error => console.error('Unable to add item.', error));
}

fetch('http://localhost:61567/TreatmentRecord')
    .then(
        function (response) {
            if (response.status !== 200) {
                console.warn('Looks like there was a problem. Status Code: ' +
                    response.status);
                return;
            }
            // Examine the text in the response  
            response.json().then(function (data) {
                let length = data.length;
                document.getElementById("total").innerHTML = length;
            })
        }
    )
    .catch(function (err) {
        console.error('Fetch Error -', err);
    });

fetch('http://localhost:61567/TreatmentRecord/Details')
    .then(
        function (response) {
            if (response.status !== 200) {
                console.warn('Looks like there was a problem. Status Code: ' +
                    response.status);
                return;
            }
            // Examine the text in the response  
            response.json().then(function (data) {
                let length = data.length;
                document.getElementById("fatal").innerHTML = length;
            })
        }
    )
    .catch(function (err) {
        console.error('Fetch Error -', err);
    });



fetch('http://localhost:61567/TreatmentRecord/Details/Cured')
    .then(
        function (response) {
            if (response.status !== 200) {
                console.warn('Looks like there was a problem. Status Code: ' +
                    response.status);
                return;
            }
            // Examine the text in the response  
            response.json().then(function (data) {
                let length = data.length;
                document.getElementById("cured").innerHTML = length;
            })
        }
    )
    .catch(function (err) {
        console.error('Fetch Error -', err);
    });


fetch('http://localhost:61567/TreatmentRecord/Details/Cured/Uncured')
    .then(
        function (response) {
            if (response.status !== 200) {
                console.warn('Looks like there was a problem. Status Code: ' +
                    response.status);
                return;
            }
            // Examine the text in the response  
            response.json().then(function (data) {
                let length = data.length;
                document.getElementById("uncured").innerHTML = length;
            })
        }
    )
    .catch(function (err) {
        console.error('Fetch Error -', err);
    });

$(document).ready(function () {
    var arrow = $(".fa-arrow-up");
    var form = $(".login-form");
    var status = false;
    $("#login").click(function (event) {
        event.preventDefault();
        if (status == false) {
            arrow.fadeIn();
            form.fadeIn();
            status = true;
        } else {
            arrow.fadeOut();
            form.fadeOut();
            status = false;
        }
    })
})  