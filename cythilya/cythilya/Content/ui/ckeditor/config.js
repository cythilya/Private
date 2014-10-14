/**
 * @license Copyright (c) 2003-2014, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    config.language = 'zh-tw';
    config.uiColor = '#BFBFBF';
    config.height = 300;
    //config.contentsCss = ['/Content/layout.css', '/Content/html.css'];
    config.toolbar_Full = [['Source', '-', 'Save', 'NewPage', 'Preview', '-', 'Templates'],
                           ['Undo', 'Redo', '-', 'SelectAll', 'RemoveFormat'],
                           ['Styles', 'Format', 'Font', 'FontSize'],
                           ['TextColor', 'BGColor'],
                           ['Maximize', 'ShowBlocks', '-', 'About'], '/',
                           ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
                           ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote', 'CreateDiv'],
                           ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
                           ['Link', 'Unlink', 'Anchor'],
                           ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'],
                           /*['Code']*/];
    /*config.extraPlugins = 'CodePlugin';*/
    config.extraPlugins = 'abbr,simpleimageupload';
    config.allowedContent = true;
};

