import xml.etree.ElementTree as ET
def leer_xml(path):
    # Parsear el archivo XML
    tree = ET.parse(path)
    root = tree.getroot()

    # Generar el string con todo el documento
    xml_string = ET.tostring(root, encoding='utf-8').decode('utf-8')
    return xml_string