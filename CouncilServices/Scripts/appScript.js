$(function () {

    
    var validStatesCustomerType = {
        "CustomerTypes":  [
                { id: '1', name: 'Citizen' },
                { id: '2', name: 'Organization' },
                { id: '3', name: 'Anonymous' }
            ]
    };
    
    /*
     * reset errors if the customer type changes and there are
     * errors on the dynamic part of the form which are now disabled.
     */
    function resetErrors() {
        $.each($("span[data-valmsg-for]"), function (index,obj) {
            obj.innerHTML = "";
        });
    }

    /*
     * find a customer id by its name
     */
    function getCustomerId(CustomerType)
    {
        var id = "";
        $(validStatesCustomerType.CustomerTypes).each(function (idx, obj) {
            if (obj.name === CustomerType) {
                console.log("Customer: " + obj.id + " " + obj.name);
                id = obj.id;
                return;
            }
        });
        return id;
        
    }

    /*
     * reset form fields
     */
    function disableAll() {
        $('#Title').prop('disabled', true);
        $('#FirstName').prop('disabled', true);
        $('#LastName').prop('disabled', true);
        $('#Organisation').prop('disabled', true);
    }

    /*
     * change the form based on CustomerType
     */
    function updateDisplay(context) {

        var value = $(context).val();
        console.log("selected type: " + value);
        if (value == '0' || value == getCustomerId('Anonymous')) {
            disableAll();
        }
        if (value == getCustomerId('Citizen')) {
            $('#Title').prop('disabled', false);
            $('#FirstName').prop('disabled', false);
            $('#LastName').prop('disabled', false);
            $('#Organisation').prop('disabled', true);
        }
        if (value == getCustomerId('Organization')) {
            $('#Title').prop('disabled', true);
            $('#FirstName').prop('disabled', true);
            $('#LastName').prop('disabled', true);
            $('#Organisation').prop('disabled', false);
        }
    }

    disableAll();
    updateDisplay($('#CustomerType'));
    
    /*
     * changing customer type changes the form
     */
    $('#CustomerType').change(function () {

        resetErrors();
        var context = $(this);
        updateDisplay(context);
    });


});