
from selenium import webdriver
from selenium.webdriver.firefox.service import Service
import json
import re
from selenium.webdriver.common.action_chains import ActionChains

#Pattern to match a href tag
HREF_PATTERN_MATCH = "a(.*?)</a"
HREF_PATTERN_SEARCH = "<a.*>(.*?)</a"

#Xpath to get all child element tags
CHILD_PATH = "./*"

#Json keys and properties
TEXT_COLOR = "text_color"
BG_COLOR = "bg_color"
FONT_SIZE = "font_size"
HREF = "href"
COLOR_CSS = "color"
BACKGROUND_COLOR_CSS = "background-color"
FONT_SIZE_CSS = "font-size"
A_TAG = "a"
IDENTIFIER = "identifier"
LOCATION = "location"
SIZE = "size"
MAIN = "main"
CHILDREN = "children"
INNER_TEXT = "inner_text"
ALLBTNS = "allbtns"
BTN = "btn"
INNER_HTML = "innerHTML"
MENU = "menu"
MENU_ELEM_ID = "nice-menu-0"
TEXT = "text"

website_link = "https://www.cs.stonybrook.edu/admissions/Graduate-Program"

def get_child_element_attributes(child):
    dictionary_final_children={}
    href_text = child.get_attribute(INNER_HTML)
    if re.search(HREF_PATTERN_MATCH, href_text):
        inner_txt = re.search(HREF_PATTERN_SEARCH, href_text).group(1)
        dictionary_final_children[TEXT] = inner_txt
    children_list = child.find_elements_by_xpath(CHILD_PATH)
    for child_elem in children_list:
        dictionary_final_children[TEXT_COLOR] = child_elem.value_of_css_property(COLOR_CSS)
        dictionary_final_children[BG_COLOR] = child_elem.value_of_css_property(BACKGROUND_COLOR_CSS)
        dictionary_final_children[FONT_SIZE] = child_elem.value_of_css_property(FONT_SIZE_CSS)
        if child_elem.tag_name == A_TAG:
            dictionary_final_children[HREF] = child_elem.get_attribute(HREF)
    return dictionary_final_children

# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    s=Service("/Users/priyankadighe/Downloads/geckodriver")
    driver = webdriver.Firefox(service=s)
    driver.implicitly_wait(0.5)
    driver.get(website_link)
    dictionary_children = {}

    # Get main menu element
    menu_element = driver.find_element_by_id(MENU_ELEM_ID)
    #actions.move_to_element(l).click().perform()
    #l.click()
    dictionary_web_struct = {}
    dictionary_menu = {}

    dictionary_menu[IDENTIFIER] = MENU
    dictionary_menu[LOCATION] = menu_element.location
    dictionary_menu[SIZE] = menu_element.size
    dictionary_menu[BG_COLOR] = menu_element.value_of_css_property(BACKGROUND_COLOR_CSS)
    dictionary_web_struct[MAIN] = dictionary_menu
    child_list = menu_element.find_elements_by_xpath(CHILD_PATH)
    i = 1
    j=1
    dictionary_outer_btn = {}
    ctr=1
    for child in child_list:
        dictionary_child = {}
        #dictionary_child['identifier'] = "btn" + str(i)

        dictionary_child[TEXT] = child.text
        dictionary_child[LOCATION] = child.location
        dictionary_child[SIZE] = child.size
        dictionary_child[FONT_SIZE]=child.value_of_css_property(FONT_SIZE_CSS)

        atag =child.find_element_by_tag_name(A_TAG)
        dictionary_child[HREF] = atag.get_attribute(HREF)
        dictionary_child[TEXT_COLOR] = atag.value_of_css_property(COLOR_CSS)
        dictionary_child[BG_COLOR] = atag.value_of_css_property(BACKGROUND_COLOR_CSS)

        if child.tag_name == A_TAG:
            dictionary_child[HREF] = child.get_attribute(HREF)
        dictionary_outer_btn[BTN + str(j)] = dictionary_child
        j = j + 1
        dictionary_web_struct[CHILDREN] = dictionary_outer_btn
        print('dictionary_web_struct',dictionary_web_struct)
        dictionary_inner_btn={}
        children_next = child.find_elements_by_xpath(CHILD_PATH)
        #ctr = 1
        ctr2=1
        list_children = []
        step=1
        phref=''
        hrefbool=True
        while children_next:
            if dictionary_inner_btn:
                if step==1:
                    step=2
                else:
                    dictionary_child[ALLBTNS] = dictionary_inner_btn
                    dictionary_outer_btn[BTN + str(j)] = dictionary_child
                    dictionary_web_struct[CHILDREN] = dictionary_outer_btn
                    print('dictionary_web_struct', dictionary_web_struct)
                    json_object = json.dumps(dictionary_web_struct, indent=4)
                    print('json display:', json_object)
                    step=1
                i=i+1
                ctr2=1
            list_children = []
            dictionary_inner_btn={}
            i=i-1
            for child_next in children_next:
                dictionary_temp = get_child_element_attributes(child_next)
                dictionary_inner_btn[BTN+str(j-1)+str(ctr2)] = dictionary_temp
                ctr2 = ctr2+1
                children_next = child_next.find_elements_by_xpath(CHILD_PATH)
    driver.quit()
