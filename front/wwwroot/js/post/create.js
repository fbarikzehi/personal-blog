


  const editor = new EditorJS({
    /**
     * Id of Element that should contain the Editor
     */
    holderId : 'editor',
  
    /**
     * Available Tools list.
     * Pass Tool's class or Settings object for each Tool you want to use
     */
    tools: {
      header: {
        class: Header,
        inlineToolbar : true,
        shortcut: 'CMD+SHIFT+H',
        config: {
          placeholder: 'Enter a header',
          levels: [2, 3, 4,6],
          defaultLevel:4
        }
      },
      image: {
        class: ImageTool,
        config: {
          endpoints: {
            byFile: 'http://localhost:8008/uploadFile', // Your backend file uploader endpoint
            byUrl: 'http://localhost:8008/fetchUrl', // Your endpoint that provides uploading by Url
          }
        }
      },
      list: {
        class: List,
        inlineToolbar: true,
        config: {
          defaultStyle: 'unordered'
        }
      },
      embed: {
        class: Embed,
        inlineToolbar: true,
        config: {
          services: {
            youtube: true,
            coub: true
          }
        }
      },
      quote: {
        class: Quote,
        inlineToolbar: true,
        shortcut: 'CMD+SHIFT+O',
        config: {
          quotePlaceholder: 'Enter a quote',
          captionPlaceholder: 'Quote\'s author',
        },
      },  
      underline: Underline
    },
    onReady: () => {
      console.log('Editor.js is ready to work!')
   },
    /**
     * Previously saved data that should be rendered
     */
    data: {}
  });

  $(function() {

    $("#ggg").click(function() {

      editor.save().then( savedData => {
        var data = JSON.stringify(savedData, null, 4);

        console.log(data)
      })
    })
  })