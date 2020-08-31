var cols = []
cols.push(
    {
        "title": "Patient Name",
        "data": "patientName",
    },
    {
        "title": "Phone Number",
        "data": "phoneNumber",
    },
    {
        "title": "Gender",
        "data": "gender",
    },
    {
        "title": "Age",
        "data": "age",
    },
    {
        "title": "Disease Type",
        "data": "diseaseType",

    },
    {
        "title": "Disease Name",
        "data": "diseaseName",
    },
    {
        "title": "Admit Date",
        "data": "admitDate",
    },
    {
        "title": "Relieving Date",
        "data": "relievingDate",
    },
    {
        "title": "Is Fatality",
        "data": "isFatality",
    },
    {
        "title": "Prescription",
        "data": "prescription",
    },
    {
        "title": "Current Stage",
        "data": "currentStage",

    },
    {
        "title": "Delete",
        "data": "patientId",
        "render": function (patientId, type, full, meta) {

            return '<a id="delid" href="#"  onClick="deletePatient(' + patientId + ')">' + "Delete" + '</a>';


        }
    },
    {
        "title": "Edit",
        "data": "patientId",
        "render": function (patientId, type, full, meta) {

            return '<a class="edit"  href="#" onClick= "editPatient(' + patientId + ')">' + "Edit" + '</a>';


        }
    },
)
    

var patientData = null;
function cured() {
        document.getElementById("demo").innerHTML = "CURED PATIENTS LIST";
    fetch("http://localhost:61567/TreatmentRecord/Details/Cured",
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
            patientData = data;
            var table = $('#patient').DataTable({
                data: data,
                "columns": cols,

            })





            })
            .catch(function (err) {
                console.error('Fetch Error -', err);
            });
}


function uncured() {
  
    document.getElementById("demo").innerHTML = "Patient Under Treatment";
    fetch("http://localhost:61567/TreatmentRecord/Details/Cured/Uncured",
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
            patientData = data;
            var table = $('#uncuredPatient').DataTable({
                data: data,
                "columns": cols,
            })
        })
        .catch(function (err) {
            console.error('Fetch Error -', err);
        });
}

function fatal() {

    document.getElementById("demo").innerHTML = "Death Patient";
    fetch("http://localhost:61567/TreatmentRecord/Details",
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
            patientData = data;
            var table = $('#fatal').DataTable({
                data: data,
                "columns": cols,
            })
        })
        .catch(function (err) {
            console.error('Fetch Error -', err);
        });
}




function deletePatient(id) {
    var result = confirm("Are you sure want to delete patient record?")
    if (result) {

        fetch('http://localhost:61567/Patient/' + id,

            {
                method: 'DELETE',

            })

            .then(function (response) {

                if (response.status == 200) {
                    window.location.reload();
                }
                else {
                    alert("Oops Got some error!.");
                }
                return response.json()


            })
        return true;
    }
    else {
        return false;
    }


}
function editPatient(id) {
    patient = patientData.filter(function (el) {

        return el.patientId == id;


    });

    document.getElementById('patientName').value = patient[0].patientName;
    document.getElementById('phoneNumber').value = patient[0].phoneNumber;
    document.getElementById('gender').value = patient[0].gender;
    document.getElementById('age').value = patient[0].age;
    document.getElementById('diseaseType').value = patient[0].diseaseType;
    document.getElementById('diseaseName').value = patient[0].diseaseName;
    document.getElementById('admitDate').value = patient[0].admitDate;
    document.getElementById('relievingDate').value = patient[0].relievingDate;
    document.getElementById('isFatality').value = patient[0].isFatality;
    document.getElementById('prescription').value = patient[0].prescription;
    document.getElementById('currentStage').value = patient[0].currentStage;


    var form = $('.update-patient');
    var status = false;

    if (status == false) {
        form.fadeIn();
        status = true;
    } else {
        form.fadeOut();
        status = false;
    }
}
function updatePatientDetail() {
    var id = patient[0].patientId;
    
    const data =
    {
        patientName: document.getElementById('patientName').value,
        phoneNumber: document.getElementById('phoneNumber').value,
        gender: document.getElementById('gender').value,
        age: parseInt(document.getElementById('age').value),
        diseaseType: document.getElementById('diseaseType').value,
        diseaseName: document.getElementById('diseaseName').value,
        admitDate: document.getElementById('admitDate').value,
        relievingDate: document.getElementById('relievingDate').value,
        isFatality: document.getElementById('isFatality').value,
        prescription: document.getElementById('prescription').value,
        currentStage: document.getElementById('currentStage').value
    };


    fetch('http://localhost:61567/Patient/' + id,
        {
            method: 'PUT',
            headers:
            {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
        .then(function (response) {
            if (response.status == 200) {
                alert("Details Updated");
                window.location.href = 'http://localhost:61567/editpatient.html';
                
            }
            return response.json();
        })
        .then((data) => {
            console.log(data);

        })

        .catch(error => console.error('Unable to update data.', error));

}
$(function () {
    $("#header").load("header.html");
    $("#footer").load("footer.html");
});
