//function cured() {
//    document.getElementById("demo").innerHTML = "CURED PATIENTS LIST";
//    fetch("http://localhost:59408/api/TreatmentRecords/GetCuredPatients")
//        .then(response => response.json())
//        .then(json => {
//            let li = `<tr>
//                        <th>Patient Name</th>
//                        <th>AadharID</th>
//                        <th>PContact</th>
//                        <th>Hospital Name</th>
//                        <th>City</th>
//                        <th>State</th>
//                        <th>Admitted Date</th>
//                        <th>Prescription</th>
//                        <th>Relieving Date</th>
//                        <th>IsFatal</th>
//                        <th>Currentstage</th>
//                        </tr>`;
//            json.forEach(patient => {
//                li += `<tr>
//            <td>${patient.patientName} </td>
//            <td>${patient.aadharID}</td>
//            <td>${patient.pContact}</td>
//            <td>${patient.hospitalName}</td>
//            <td>${patient.city}</td>
//            <td>${patient.state}</td>
//            <td>${patient.admittedDate}</td>
//            <td>${patient.prescription}</td>
//            <td>${patient.relievingDate}</td>
//            <td>${patient.isFatal}</td>
//            <td>${patient.currentstage}</td>
//        </tr>`;
//            });
//            document.getElementById("patients").innerHTML = li;
//        });
//}
var patientData = null;
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
    //{
    //    "title": "Edit",
    //    "data": "patientId",
    //    "render": function (patientId, type, full, meta) {

    //        return '<a class="edit"  href="#" onClick= "editPatient(' + patientId + ')">' + "Edit" + '</a>';


    //    }
    //},
    {
        "title": "Delete",
        "data": "patientId",
        "render": function (patientId, type, full, meta) {

            return '<a id="delid" href="#"  onClick="deletePatient(' + patientId + ')">' + "Delete" + '</a>';


        }
    },
    
)
function cured() {
    document.getElementById("demo").innerHTML = "CURED PATIENTS LIST";
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
                    var table = $('#patients').DataTable({
                        patientData: data,
                        "columns": cols
                            
                        
                    })



                    
                })
            }
        )
        .catch(function (err) {
            console.error('Fetch Error -', err);
        });
}

function uncured() {
  
    document.getElementById("demo").innerHTML = "Patient Under Treatment";
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
                    var table = $('#uncured').DataTable({
                        patientData: data,
                        "columns": cols


                    })





                })
            }
        )
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
}
