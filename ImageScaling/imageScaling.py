
#program to test bicubic interpolation
#Reference :https://www.geeksforgeeks.org/python-opencv-bicubic-interpolation-for-resizing-image/

import cv2
import numpy as np
img_path = "/Users/priyankadighe/Downloads/img_to_scale.jpg"
output_path = "/Users/priyankadighe/Downloads/scaled_img.jpg"

if __name__ == '__main__':
    img = cv2.imread(img_path,1)
    bicubic_img = cv2.resize(img,None, fx = 2, fy = 2, interpolation = cv2.INTER_CUBIC)

    cv2.imshow('scaled image',bicubic_img)
    cv2.imwrite("scaled_img.jpg", bicubic_img)
    cv2.waitKey(0)
    cv2.destroyAllWindows()