Dropzone.autoDiscover = false;
window.onload = function () {

    var dropzoneOptions = {
        dictDefaultMessage: 'Drop Here!',
        acceptedFiles: ".xml",
        paramName: "files",
        uploadMultiple: true,
        maxFilesize: 5, // MB
        addRemoveLinks: true,
        createImageThumbnails: true,
        init: function () {
            this.on("success", function (file) {
                console.log("success > " + file.name);
            });
        }
    };
    var uploader = document.querySelector('#portfolioUploadDropZone');
    var newDropzone = new Dropzone(uploader, dropzoneOptions);

    console.log("Loaded");
};