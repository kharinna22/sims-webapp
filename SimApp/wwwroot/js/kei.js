FamilyTree.templates.john = Object.assign({}, FamilyTree.templates.base);
FamilyTree.templates.john.defs = `<style>
                                        .{randId} .bft-edit-form-header, .{randId} .bft-img-button{
                                            background-color: #aeaeae;
                                        }
                                        .{randId}.male .bft-edit-form-header, .{randId}.male .bft-img-button{
                                            background-color: #039BE5;
                                        }        
                                        .{randId}.male div.bft-img-button:hover{
                                            background-color: #F57C00;
                                        }
                                        .{randId}.female .bft-edit-form-header, .{randId}.female .bft-img-button{
                                            background-color: #F57C00;
                                        }        
                                        .{randId}.female div.bft-img-button:hover{
                                            background-color: #039BE5;
                                        }
                                    </style>
                                    <clipPath id="john_img_0"><rect x="6" y="6" rx="54" ry="54" width="108" height="108"></rect></clipPath>
                                    ${FamilyTree.gradientCircleForDefs('circle', '#aeaeae', 60, 5)}
                                    ${FamilyTree.gradientCircleForDefs('male_circle', '#039BE5', 60, 5)}
                                    ${FamilyTree.gradientCircleForDefs('female_circle', '#F57C00', 60, 5)}`;
FamilyTree.templates.john.field_0 =
    '<text ' + FamilyTree.attr.width + ' ="230" style="font-size: 16px;font-weight:bold;" fill="#aeaeae" x="60" y="135" text-anchor="middle">{val}</text>';
FamilyTree.templates.john.field_1 =
    '<text ' + FamilyTree.attr.width + ' ="150" style="font-size: 13px;" fill="#aeaeae" x="60" y="150" text-anchor="middle">{val}</text>';
FamilyTree.templates.john.node = '<use x="0" y="0" xlink:href="#circle" />';
FamilyTree.templates.john.img_0 =
    '<image preserveAspectRatio="xMidYMid slice" clip-path="url(#john_img_0)" xlink:href="{val}" x="6" y="6" width="108" height="108"></image>';
FamilyTree.templates.john.ripple = {
    radius: 60,
    color: "#e6e6e6",
    rect: null
};

FamilyTree.templates.john.size = [120, 120]
FamilyTree.templates.john_male = Object.assign({}, FamilyTree.templates.john);
FamilyTree.templates.john_male.node += '<use x="0" y="0" xlink:href="#male_circle" />';
FamilyTree.templates.john_male.ripple = {
    radius: 60,
    color: "#039BE5",
    rect: null
};
FamilyTree.templates.john_female = Object.assign({}, FamilyTree.templates.john);
FamilyTree.templates.john_female.node += '<use x="0" y="0" xlink:href="#female_circle" />';
FamilyTree.templates.john_female.ripple = {
    radius: 60,
    color: "#F57C00",
    rect: null
};