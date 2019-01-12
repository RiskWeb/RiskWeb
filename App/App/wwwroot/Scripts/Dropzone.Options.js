Dropzone.autoDiscover = false;
window.onload = function () {

    var dropzoneOptions = {
        dictDefaultMessage: 'Drop Here!',
        autoDiscover: false,
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
        },
        init: function() {
            this.on("removedfile", function (file) {
                //add in your code to delete the file from the database here 
            });
        }
    };
    var uploader = document.querySelector('#portfolioUploadDropZone');
    var newDropzone = new Dropzone(uploader, dropzoneOptions);

    console.log("Loaded");
};