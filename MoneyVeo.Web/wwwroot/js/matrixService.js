var matrixService = {
    getRandomMatrixRequest(callBack) {
        $.getJSON(`${window.location}/GetRandomMatrix`, function (data) { callBack(data); });
    },

    getCsvRequest(data) {
        $.post(`${window.location}/GetCsvMatrix`, { matrix: data }).then(function (response) {
            var text = response;
            var filename = "matrix";
            var blob = new Blob([text], { type: "text/plain;charset=utf-8" });
            saveAs(blob, filename + ".csv");
        });
    },

    getRotatedMatrixRequest(data, callBack) {
        $.ajax({
            url: `${window.location}/RotateMatrix`,
            method: 'POST',
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: callBack
        });
    }
}