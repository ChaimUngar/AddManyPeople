$(() => {
    let pplOf = 0;

    $("#add-rows").on('click', function () {
        console.log('clicky!!!')
        pplOf++;

        $("#ppl-rows").append(`
                        <div class='row person-row' style='margin-bottom: 10px;'>

                            <div class='col-md-4'>
                                <input class='form-control' type='text' name='ppl[${pplOf}].firstname' placeholder='First Name'>
                            </div>

                            <div class='col-md-4'>
                                <input class='form-control' type='text' name='ppl[${pplOf}].lastname' placeholder='Last Name'>
                            </div>

                            <div class='col-md-4'>
                                <input class='form-control' type='text' name='ppl[${pplOf}].age' placeholder='Age'>
                            </div>
                        </div>`)
    })
})