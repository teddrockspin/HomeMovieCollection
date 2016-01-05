$(function () {

    var HomeMovies = {};

    HomeMovies.GridManager = {};

    //************************* Movies GRID
    HomeMovies.GridManager.moviesGrid = function (gridName, pagerName) {

        //*** Event handlers
        var afterclickPgButtons = function (whichbutton, formid, rowid) {
            tinyMCE.get("Summary").setContent(formid[0]["Summary"].value);
            tinyMCE.get("Description").setContent(formid[0]["Description"].value);
        };

        var afterShowForm = function (form) {
            tinyMCE.execCommand('mceAddControl', false, "Summary");
            tinyMCE.execCommand('mceAddControl', false, "Description");
        };

        var onClose = function (form) {
            tinyMCE.execCommand('mceRemoveControl', false, "Summary");
            tinyMCE.execCommand('mceRemoveControl', false, "Description");
        };

        var beforeSubmitHandler = function (postdata, form) {
            var selRowData = $(gridName).getRowData($(gridName).getGridParam('selrow'));
            if (selRowData["ReleaseDate"])
                postdata.PostedOn = selRowData["ReleaseDate"];
            postdata.ShortDescription = tinyMCE.get("Summary").getContent();
            postdata.Description = tinyMCE.get("Description").getContent();

            return [true];
        };

        var colNames = [
                'MovieId',
                'Title',
                'Summary',
                'Description',
                'Format',
                'Region',
                'RunTime',
                'Genre',
                'Genre',
                'Actors',
                'Director',
                'Url Slug',
                'Release Date',
                'AddedOn',
                'Modified'
        ];

        var columns = [];

        columns.push({
            name: 'MovieId',
            hidden: true,
            key: true
        });

        columns.push({
            name: 'Title',
            index: 'Title',
            width: 250,
            editable: true,
            editoptions: {
                size: 43,
                maxlength: 500
            },
            editrules: {
                required: true
            },
            formatter: 'showlink',
            formatoptions: {
                target: "_new",
                baseLinkUrl: '/Admin/GoToMovie'
            }
        });

        columns.push({
            name: 'Summary',
            index: 'Summary',
            width: 250,
            editable: true,
            sortable: false,
            hidden: true,
            edittype: 'textarea',
            editoptions: {
                rows: "10",
                cols: "100"
            },
            editrules: {
                //custom: true,
                //custom_func: function (val, colname) {
                //  val = tinyMCE.get("Summary").getContent();
                //  if (val) return [true, ""];
                //  return [false, colname + ": Field is required"];
                //},
                edithidden: true
            }
        });

        columns.push({
            name: 'Description',
            index: 'Description',
            width: 250,
            editable: true,
            sortable: false,
            hidden: true,
            edittype: 'textarea',
            editoptions: {
                rows: "40",
                cols: "100"
            },
            editrules: {
                //custom: true,
                //custom_func: function (val, colname) {
                //  val = tinyMCE.get("Description").getContent();
                //  if (val) return [true, ""];
                //  return [false, colname + ": Field is requred"];
                //},
                edithidden: true
            }
        });

        columns.push({
            name: 'Format',
            index: 'Format',
            width: 250,
            editable: true,
            editoptions: {
                size: 43,
                maxlength: 100
            },
            editrules: {
                required: false
            }
        });

        columns.push({
            name: 'Region',
            index: 'Region',
            width: 250,
            editable: true,
            editoptions: {
                size: 43,
                maxlength: 100
            },
            editrules: {
                required: false
            }
        });

        columns.push({
            name: 'RunTime',
            index: 'RunTime',
            width: 250,
            editable: true,
            editoptions: {
                size: 43,
                maxlength: 100
            },
            editrules: {
                required: false
            }
        });

        columns.push({
            name: 'Genre.GenreId',
            hidden: true,
            editable: true,
            edittype: 'select',
            editoptions: {
                style: 'width:250px;',
                dataUrl: '/Admin/GetGenresHtml'
            },
            editrules: {
                required: true,
                edithidden: true
            }
        });

        columns.push({
            name: 'Genre.Name',
            index: 'Genre',
            width: 150
        });

        columns.push({
            name: 'Actors',
            width: 150,
            editable: true,
            edittype: 'select',
            editoptions: {
                style: 'width:250px;',
                dataUrl: '/Admin/GetActorsHtml',
                multiple: true
            },
            editrules: {
                required: true
            }
        });

        columns.push({
            name: 'Director',
            index: 'Director',
            width: 250,
            editable: true,
            editoptions: {
                size: 43,
                maxlength: 100
            },
            editrules: {
                required: false
            }
        });

        columns.push({
            name: 'UrlSlug',
            width: 200,
            sortable: false,
            editable: true,
            editoptions: {
                size: 43,
                maxlength: 200
            },
            editrules: {
                required: true
            }
        });

        columns.push({
            name: 'ReleaseDate',
            index: 'ReleaseDate',
            editable: true,
            hidden: false,
            width: 150,
            align: 'center',
            sorttype: 'date',
            datefmt: 'm/d/Y'
        });

        columns.push({
            name: 'AddedOn',
            index: 'AddedOn',
            editable: true,
            hidden: true,
            width: 150,
            align: 'center',
            sorttype: 'date',
            datefmt: 'm/d/Y'
        });

        columns.push({
            name: 'Modified',
            index: 'Modified',
            width: 100,
            align: 'center',
            sorttype: 'date',
            datefmt: 'm/d/Y'
        });


        $(gridName).jqGrid({
            url: '/Admin/Movies',
            datatype: 'json',
            mtype: 'GET',
            height: 'auto',
            toppager: true,
            colNames: colNames,
            colModel: columns,

            pager: pagerName,
            rownumbers: true,
            rownumWidth: 40,
            rowNum: 10,
            rowList: [10, 20, 30],

            sortname: 'ReleaseDate',
            sortorder: 'desc',
            viewrecords: true,

            jsonReader: {
                repeatitems: false
            },

            afterInsertRow: function (rowid, rowdata, rowelem) {

                var actors = rowdata["Actors"];
                var actorStr = "";

                $.each(actors, function (i, a) {
                    if (actorStr) actorStr += ", "
                    actorStr += a.FirstName + ' ' + a.LastName;
                });


                $(gridName).setRowData(rowid, { "Actors": actorStr });
            }
        });

        // configuring add options
        var addOptions = {
            url: '/Admin/AddMovie',
            addCaption: 'Add Movie',
            processData: "Saving...",
            width: 900,
            closeAfterAdd: true,
            closeOnEscape: true,
            afterclickPgButtons: afterclickPgButtons,
            afterShowForm: afterShowForm,
            onClose: onClose,
            afterSubmit: HomeMovies.GridManager.afterSubmitHandler,
            beforeSubmit: beforeSubmitHandler
        };

        var editOptions = {
            url: '/Admin/EditMovie',
            editCaption: 'Edit Movie',
            processData: "Saving...",
            width: 900,
            closeAfterEdit: true,
            closeOnEscape: true,
            afterclickPgButtons: afterclickPgButtons,
            afterShowForm: afterShowForm,
            onClose: onClose,
            afterSubmit: HomeMovies.GridManager.afterSubmitHandler,
            beforeSubmit: beforeSubmitHandler
        };

        var deleteOptions = {
            url: '/Admin/DeleteMovie',
            caption: 'Delete Movie',
            processData: "Saving...",
            msg: "Delete the Movie?",
            closeOnEscape: true,
            afterSubmit: HomeMovies.GridManager.afterSubmitHandler
        };

        console.log(HomeMovies);

        $(gridName).navGrid(pagerName, { cloneToTop: true, search: false }, editOptions, addOptions, deleteOptions);
    };

    //************************* Genres GRID
    HomeMovies.GridManager.genresGrid = function (gridName, pagerName) {
        var colNames = ['GenreId', 'Name', 'Url Slug', 'Description'];

        var columns = [];

        columns.push({
            name: 'GenreId',
            index: 'GenreId',
            hidden: true,
            sorttype: 'int',
            key: true,
            editable: true,
            editoptions: {
                readonly: true
            }
        });

        columns.push({
            name: 'Name',
            index: 'Name',
            width: 200,
            editable: true,
            edittype: 'text',
            editoptions: {
                size: 30,
                maxlength: 50
            },
            editrules: {
                required: true
            }
        });

        columns.push({
            name: 'UrlSlug',
            index: 'UrlSlug',
            width: 200,
            editable: true,
            edittype: 'text',
            sortable: false,
            editoptions: {
                size: 30,
                maxlength: 50
            },
            editrules: {
                required: true
            }
        });

        columns.push({
            name: 'Description',
            index: 'Description',
            width: 200,
            editable: true,
            edittype: 'textarea',
            sortable: false,
            editoptions: {
                rows: "4",
                cols: "28"
            }
        });

        $(gridName).jqGrid({
            url: '/Admin/Genres',
            datatype: 'json',
            mtype: 'GET',
            height: 'auto',
            toppager: true,
            colNames: colNames,
            colModel: columns,
            pager: pagerName,
            rownumbers: true,
            rownumWidth: 40,
            rowNum: 500,
            sortname: 'Name',
            loadonce: true,
            jsonReader: {
                repeatitems: false
            }
        });

        var editOptions = {
            url: '/Admin/EditGenre',
            width: 400,
            editCaption: 'Edit Genre',
            processData: "Saving...",
            closeAfterEdit: true,
            closeOnEscape: true,
            afterSubmit: function (response, postdata) {
                var json = $.parseJSON(response.responseText);

                if (json) {
                    $(gridName).jqGrid('setGridParam', { datatype: 'json' });
                    return [json.success, json.message, json.id];
                }

                return [false, "Failed to get result from server.", null];
            }
        };

        var addOptions = {
            url: '/Admin/AddGenre',
            width: 400,
            addCaption: 'Add Genre',
            processData: "Saving...",
            closeAfterAdd: true,
            closeOnEscape: true,
            afterSubmit: function (response, postdata) {
                var json = $.parseJSON(response.responseText);

                if (json) {
                    $(gridName).jqGrid('setGridParam', { datatype: 'json' });
                    return [json.success, json.message, json.id];
                }

                return [false, "Failed to get result from server.", null];
            }
        };

        var deleteOptions = {
            url: '/Admin/DeleteGenre',
            caption: 'Delete Genre',
            processData: "Saving...",
            width: 500,
            msg: "Delete the Gnere? This will delete all the movies belonged to this category as well.",
            closeOnEscape: true,
            afterSubmit: HomeMovies.GridManager.afterSubmitHandler
        };

        // configuring the navigation toolbar.
        $(gridName).jqGrid('navGrid', pagerName, {
            cloneToTop: true,
            search: false
        },

        editOptions, addOptions, deleteOptions);
    };

    //************************* Actors GRID
    HomeMovies.GridManager.actorsGrid = function (gridName, pagerName) {
        var colNames = ['ActorId', 'FirstName', 'LastName', 'Url Slug', 'Description'];

        var columns = [];

        columns.push({
            name: 'ActorId',
            index: 'ActorId',
            hidden: true,
            sorttype: 'int',
            key: true,
            editable: true,
            editoptions: {
                readonly: true
            }
        });

        columns.push({
            name: 'FirstName',
            index: 'FirstName',
            width: 200,
            editable: true,
            edittype: 'text',
            editoptions: {
                size: 30,
                maxlength: 50
            },
            editrules: {
                required: true
            }
        });

        columns.push({
            name: 'LastName',
            index: 'LastName',
            width: 200,
            editable: true,
            edittype: 'text',
            editoptions: {
                size: 30,
                maxlength: 50
            },
            editrules: {
                required: true
            }
        });

        columns.push({
            name: 'UrlSlug',
            index: 'UrlSlug',
            width: 200,
            editable: true,
            edittype: 'text',
            sortable: false,
            editoptions: {
                size: 30,
                maxlength: 50
            },
            editrules: {
                required: true
            }
        });

        columns.push({
            name: 'Description',
            index: 'Description',
            width: 200,
            editable: true,
            edittype: 'textarea',
            sortable: false,
            editoptions: {
                rows: "4",
                cols: "28"
            }
        });

        $(gridName).jqGrid({
            url: '/Admin/Actors',
            datatype: 'json',
            mtype: 'GET',
            height: 'auto',
            toppager: true,
            colNames: colNames,
            colModel: columns,
            pager: pagerName,
            rownumbers: true,
            rownumWidth: 40,
            rowNum: 500,
            sortname: 'Name',
            loadonce: true,
            jsonReader: {
                repeatitems: false
            }
        });

        var editOptions = {
            url: '/Admin/EditActor',
            editCaption: 'Edit Tag',
            processData: "Saving...",
            closeAfterEdit: true,
            closeOnEscape: true,
            width: 400,
            afterSubmit: function (response, postdata) {
                var json = $.parseJSON(response.responseText);

                if (json) {
                    $(gridName).jqGrid('setGridParam', { datatype: 'json' });
                    return [json.success, json.message, json.id];
                }

                return [false, "Failed to get result from server.", null];
            }
        };

        var addOptions = {
            url: '/Admin/AddActor',
            addCaption: 'Add Actor',
            processData: "Saving...",
            closeAfterAdd: true,
            closeOnEscape: true,
            width: 400,
            afterSubmit: function (response, postdata) {
                var json = $.parseJSON(response.responseText);

                if (json) {
                    $(gridName).jqGrid('setGridParam', { datatype: 'json' });
                    return [json.success, json.message, json.id];
                }

                return [false, "Failed to get result from server.", null];
            }
        };

        var deleteOptions = {
            url: '/Admin/DeleteActor',
            caption: 'Delete Actor',
            processData: "Saving...",
            width: 500,
            msg: "Delete the actor?",
            closeOnEscape: true,
            afterSubmit: HomeMovies.GridManager.afterSubmitHandler
        };

        // configuring the navigation toolbar.
        $(gridName).jqGrid('navGrid', pagerName, {
            cloneToTop: true,
            search: false
        },

        editOptions, addOptions, deleteOptions);
    };

    HomeMovies.GridManager.afterSubmitHandler = function (response, postdata) {

        var json = $.parseJSON(response.responseText);

        if (json) return [json.success, json.message, json.id];

        return [false, "Failed to get result from server.", null];
    };


    //sets up jquery tabs.
    $("#tabs").tabs({
        show: function (event, ui) {

            if (!ui.tab.isLoaded) {

                var gdMgr = HomeMovies.GridManager,
                        fn, gridName, pagerName;

                switch (ui.index) {
                    case 0:
                        fn = gdMgr.moviesGrid;
                        gridName = "#tableMovies";
                        pagerName = "#pagerMovies";
                        break;
                    case 1:
                        fn = gdMgr.genresGrid;
                        gridName = "#tableGenres";
                        pagerName = "#pagerGenres";
                        break;
                    case 2:
                        fn = gdMgr.actorsGrid;
                        gridName = "#tableActors";
                        pagerName = "#pagerActors";
                        break;
                };

                fn(gridName, pagerName);
                ui.tab.isLoaded = true;
            }
        }
    });
});
