const uri = 'http://localhost:61567/Hospital';
function addHospitalDetail() {
    const addNameTextbox = document.getElementById('hos_name');
    const addPhoneTextbox = document.getElementById('hos_number');
    const addStreetTextbox = document.getElementById('street');
    const addAreaTextbox = document.getElementById('area');
    const addCityTextbox = document.getElementById('city');
    const addStateTextbox = document.getElementById('state');
    const addCountryTextbox = document.getElementById('country');
    const addZipCodeTextbox = document.getElementById('zip_code');

    const data =
    {
        hospitalName: addNameTextbox.value.trim(),
        hospitalPhoneNumber: addPhoneTextbox.value.trim(),
        streetNumber: addStreetTextbox.value.trim(),
        area: addAreaTextbox.value.trim(),
        city: addCityTextbox.value.trim(),
        state: addStateTextbox.value.trim(),
        country: addCountryTextbox.value.trim(),
        zipcode: addZipCodeTextbox.value.trim()
    };
    fetch(uri,
        {
            method: 'POST',
            headers:
            {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
        .then(function (res) {
            return res.json();
        })
        .then((data) => {
            console.log(data);
            let hospitalid = data;
            localStorage.setItem("hospitalid", hospitalid);
            console.log(hospitalid);
            localStorage.getItem("hospitalid");
            window.location.href = 'http://localhost:61567/treatmentDetail.html'
        })

        .catch(error => console.error('Unable to add data.', error));

}

var cols = []
cols.push(
    {
        "title": "Hospital Id",
        "data": "hospitalId",

    },
              
    {
        "title": "Hospital Name",
        "data": "hospitalName",
    },


    {
        "title": "Hospital Phone Number",
        "data": "hospitalPhoneNumber",
    },
    {
        "title": "Street Number",
        "data": "streetNumber",
    },

    {
        "title": "Area",
        "data": "area",
    },

    {
        "title": "City",
        "data": "city",
    },

    {
        "title": "State",
        "data": "state",
    },

    {
        "title": "Country",
        "data": "country",
    },

    {
        "title": "Zipcode",
        "data": "zipCode",
    },
    {
        "title": "Delete",
        "data": "hospitalId",
        "render": function (hospitalId, type, full, meta) {
            
            return '<a id="delid" href="#"  onClick="deleteHospital('+ hospitalId +')">'+"Delete"+'</a>';
            
            
        }
    },
    {
        "title": "Edit",
        "data": "hospitalId",
        "render": function (hospitalId, type, full, meta) {

            return '<a class="edit"  href="#" onClick= "editpopup(' + hospitalId +')">' + "Edit" + '</a>';


        }
    },
)

function editpopup(id) {
    hospital = hospitaldata.filter(function (el) {
        
        return el.hospitalId == id;


    });


    //$('#hospital_name').val(hospital[0].hospitalName);
    //$('hospital_number').val(hospital[0].hospitalPhoneNumber);
    //$('hos_street').val(hospital[0].streetumber);
    //$('hos_area').val(hospital[0].area);
    //$('hos_city').val(hospital[0].city);
    //$('hos_state').val(hospital[0].state);
    //$('hos_country').val(hospital[0].country);
    //$('hos_zip_code').val(hospital[0].zipCode);
    //localStorage.setItem("hos_id", hospital[0].hospitalId);
    document.getElementById('hospital_name').value = hospital[0].hospitalName;
    document.getElementById('hospital_number').value = hospital[0].hospitalPhoneNumber;
    document.getElementById('hos_street').value = hospital[0].streetNumber;
    document.getElementById('hos_area').value = hospital[0].area;
    document.getElementById('hos_city').value = hospital[0].city;
    document.getElementById('hos_state').value = hospital[0].state;
    document.getElementById('hos_country').value = hospital[0].country;
    document.getElementById('hos_zip_code').value = hospital[0].zipCode;


    var form = $('.update-form');
    var status = false;

    if (status == false) {
        form.fadeIn();
        status = true;
    } else {
        form.fadeOut();
        status = false;
    }
}

function updateHospitalDetail() {
    var id = hospital[0].hospitalId;
        const data =
        {
            hospitalName: document.getElementById('hospital_name').value,
            hospitalPhoneNumber: document.getElementById('hospital_number').value,
            streetNumber: document.getElementById('hos_street').value,
            area: document.getElementById('hos_area').value,
            city: document.getElementById('hos_city').value,
            state: document.getElementById('hos_state').value,
            country: document.getElementById('hos_country').value,
            zipcode: document.getElementById('hos_zip_code').value
        };


        fetch('http://localhost:61567/Hospital/' + id,
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
                                       // window.location.href ='http://localhost:61567/hospital.html';
                    
                }
                return response.json();
            })
            .then((data) => {
                console.log(data);

            })

        .catch(error => console.error('Unable to update data.', error));
}






var hospitaldata = null;

    $(document).ready(function get() {


        fetch("http://localhost:61567/Hospital",
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
                hospitaldata = data;
                var table = $('#table').DataTable({
                    data: data,
                    "columns": cols,

                })




                $('#table tbody').on('dblclick', 'tr', function () {
                    var tableData = $(this).children("td").map(function () {
                        return $(this).text();
                    }).get();


                    alert("Your selected hospital is: " + $.trim(tableData[0]) + " , " + $.trim(tableData[1]) + " , " + $.trim(tableData[2]) + " , " + $.trim(tableData[3]) + " , " + $.trim(tableData[4]) + " , " + $.trim(tableData[5]) + " , " + $.trim(tableData[6]) + " , " + $.trim(tableData[7]) + " , " + $.trim(tableData[8]) + " , " + $.trim(tableData[9]));

                    let hospitalid = $.trim(tableData[0]);
                    localStorage.setItem("hospitalid", hospitalid);
                    console.log(hospitalid);
                    localStorage.getItem("hospitalid");
                    window.location.href = 'http://localhost:61567/treatmentDetail.html'
                });


            })
    });





    



function deleteHospital(id) {
    var result = confirm("Are you sure want to delete record?")
    if (result) {

        fetch('http://localhost:61567/Hospital/' + id,

            {
                method: 'DELETE',

            })

            .then(function (response) {

                if (response.status == 200) {
                   // window.location.reload();
                    get();
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
$(function () {
    $("#header").load("header.html");
    $("#footer").load("footer.html");
});
