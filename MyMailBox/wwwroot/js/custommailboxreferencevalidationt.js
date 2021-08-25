$(function () {
  jQuery.validator.addMethod('mailboxreference',
    function (value, element, params) {
      // Get element value.
      var inputReference = $(element).val();
      var expectedLetter = params[0];
      if (inputReference.length > 0) {
        return inputReference[0] === expectedLetter[0];
      }
      return true;
    });

  jQuery.validator.unobtrusive.adapters.add('mailboxreference',
    ['letter'],
    function (options) {
      options.rules['mailboxreference'] = [/*element,*/ options.params['letter']];
      options.messages['mailboxreference'] = options.message;
    });
}(jQuery));
