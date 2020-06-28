$(document).ready(function () {
    fetch("http://localhost:61567/TreatmentRecord",
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
            var table = $('#table').DataTable({
                data: data,
                "columns": [
                    { "data": "patientName" },
                    { "data": "phoneNumber" },
                    { "data": "gender" },
                    { "data": "age" },
                    { "data": "uniqueIdType" },
                    { "data": "uniqueidNumber" },
                    { "data": "streetNumber" },
                    { "data": "area" },
                    { "data": "city" },
                    { "data": "state" },
                    { "data": "country" },
                    { "data": "zipCode" },

                    { "data": "organisationName" },
                    { "data": "orgPhoneNumber"},
                    { "data": "workType"},
                    { "data": "designation"},
                    { "data": "ocp_StreetNumber" },
                    { "data": "ocp_Area" },
                    { "data": "ocp_City" },
                    { "data": "ocp_State" },
                    { "data": "ocp_Country" },
                    { "data": "ocp_ZipCode" },
                    
                    { "data": "hospitalName" },
                    { "data": "hospitalPhoneNumber" },
                    { "data": "hosp_StreetNumber" },
                    { "data": "hosp_Area" },
                    { "data": "hosp_City" },
                    { "data": "hosp_State" },
                    { "data": "hosp_Country" },
                    { "data": "hosp_ZipCode" },


                    { "data": "diseaseType"},
                    { "data": "admitDate" },
                    { "data": "relievingDate" },
                    { "data": "isFatality" },
                    { "data": "prescription" },
                    { "data": "currentStage" }

                ]

            })
        })
});


$(document).ready(function () {
    fetch("http://localhost:61567/TreatmentRecord",
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
            var table = $('#table_one').DataTable({
                data: data,
                "columns": [
                    { "data": "patientName" },
                    
                   // { "data": "area" },
                    //{ "data": "city" },
                    { "data": "state" },
                    { "data": "country" },
                    


                    { "data": "hospitalName" },


                    //{ "data": "admitDate" },
                    { "data": "diseaseType" },
                    { "data": "isFatality" },
                    //{ "data": "prescription" },
                    //{ "data": "currentStage" }

                ]

            })
        })
});