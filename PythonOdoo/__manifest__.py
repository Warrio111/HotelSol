{
    'name': "Infraninjas Hotel Import",
    'version': '1.0',
    'category': 'Custom',
    'summary': 'Importar y Exportar XML',
    'depends': ['base'],
    'data': [
       'security/ir.model.access.csv',
        'views/FacturaView.xml',
        'menu.xml',
    ],
    'installable': True,
    'application': True,
    
}



