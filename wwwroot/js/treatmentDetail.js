const uri = 'http://localhost:61567/TreatmentDetail';
function addTreatmentDetail() {
    const addAdmitTextbox = document.getElementById('admit_date');
    const addPrescriptionTextbox = document.getElementById('prescription');
    const addReleivingTextbox = document.getElementById('rel_date');
    const addFatalTextbox = fatal();
    const addStageTextbox = document.getElementById('stage');
           
    const item =
    {
        admitDate: addAdmitTextbox.value,
        prescription: addPrescriptionTextbox.value.trim(),
        relievingDate: addReleivingTextbox.value,
        isFatality: addFatalTextbox,
        stageid: parseInt(addStageTextbox.value.trim())

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
        .then(function (res) {
            return res.json();
        })
        .then((item) => {
            console.log(item);
            let treatmentid = item;
            localStorage.setItem("treatmentid", treatmentid);
            console.log(treatmentid);
            localStorage.getItem("treatmentid");
            addTreatmentRecord();
            window.location.href = 'http://localhost:61567/record.html'

        })
        
        .catch(error => console.error('Unable to add item.', error));

}
function fatal() {
    var g = document.getElementById("fatal");
    var getfatal = g.options[g.selectedIndex].text;
    document.getElementsByClassName("fatal").innerHTML = getfatal;
    return getfatal;
}



(function () {
    getStage()

})();

function getStage() {
    const url = 'http://localhost:61567/Stage';
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
            data.forEach((stage) => {
                result +=
                    '<option value="' + stage['stageId'] + '">' + stage['currentStage'] + '</option>';
                document.getElementById('stage').innerHTML = result;
            });
        })
        .catch(error => console.error('Unable to load stage.', error));
}

const url = 'http://localhost:61567/Disease';
function addDisease() {
    
    const addDiseaseNameTextbox = GetDiseaseName();
    const addDiseaseTypeTextbox = document.getElementById('diseaseType');

    const item =
    {
        diseaseName: addDiseaseNameTextbox,
        diseaseType: addDiseaseTypeTextbox.value.trim()
    };
    fetch(url,
        {
            method: 'POST',
            headers:
            {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(item)
        })
        .then(function (res) {
            return res.json();
        })
        .then((item) => {
            console.log(item);
            let diseaseid = item;
            localStorage.setItem("diseaseid", diseaseid);
            console.log(diseaseid);
            localStorage.getItem("diseaseid");
            

        })
        .catch(error => console.error('Unable to add disease.', error));

}

function GetDiseaseName() {
    var g = document.getElementById("diseaseName");
    var getDiseaseName = g.options[g.selectedIndex].text;
    document.getElementsByClassName("diseaseName").innerHTML = getDiseaseName;
    return getDiseaseName;
}



function addTreatmentRecord() {
    const addpatient = localStorage.getItem("patientid");
    const addhospital = localStorage.getItem("hospitalid");
    //const adddisease = passDisease();
    const adddisease = localStorage.getItem("diseaseid");
    //const addtreatment = passTreatment();
    const addtreatment = localStorage.getItem("treatmentid");

    const record = {

        patientid: parseInt(addpatient),
        hospitalid: parseInt(addhospital),
        diseaseid: parseInt(adddisease),
        treatmentid: parseInt(addtreatment)
    };

    fetch('http://localhost:61567/TreatmentRecord',
        {
            method: 'POST',
            headers:
            {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(record)
        })

        .then((record) => {
            console.log(record);
            
        })

        .catch(error => console.error('Unable to add record.', error));

}

//function passDisease() {
//    var diseaseid = localStorage.getItem("diseaseid");
//    return diseaseid;
//}
//function passTreatment() {
//    var treatmentid = localStorage.getItem("treatmentid");
//    return treatmentid;
//}